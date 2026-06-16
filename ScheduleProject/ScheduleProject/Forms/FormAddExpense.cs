using ScheduleProject.Data;
using ScheduleProject.Models;
using ScheduleProject.Services;

namespace ScheduleProject
{
    public partial class FormAddExpense : Form
    {
        private readonly GrokService grokService = new GrokService();

        public FormAddExpense()
        {
            InitializeComponent();
            comboCategory.SelectedIndex = 0;
            comboPaymentMethod.SelectedIndex = 0;
            dateExpense.Value = DateTime.Today;
        }

        private async void buttonAnalyzeAi_Click(object sender, EventArgs e)
        {
            string naturalText = textNaturalExpense.Text.Trim();
            if (string.IsNullOrWhiteSpace(naturalText))
            {
                MessageBox.Show("AI가 분석할 지출 문장을 입력해 주세요.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNaturalExpense.Focus();
                return;
            }

            await RunAiAnalysisAsync(() => grokService.ParseNaturalExpenseAsync(naturalText), "AI 분석 결과를 입력칸에 채웠습니다.");
        }

        private async void buttonReceiptAi_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "영수증 사진 선택",
                Filter = "이미지 파일|*.jpg;*.jpeg;*.png;*.gif;*.webp|모든 파일|*.*",
                Multiselect = false
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            await RunAiAnalysisAsync(() => grokService.ParseReceiptImageAsync(dialog.FileName), "영수증 분석 결과를 입력칸에 채웠습니다.");
        }

        private async Task RunAiAnalysisAsync(Func<Task<NaturalExpenseResult>> analyze, string successMessage)
        {
            SetAiLoadingState(true);

            try
            {
                NaturalExpenseResult result = await analyze();
                ApplyAiResult(result);
                MessageBox.Show(successMessage + " 저장 전에 내용을 확인해 주세요.", "AI 분석 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"AI 분석에 실패했습니다.\n{ex.Message}\n\n직접 입력은 계속 사용할 수 있습니다.", "AI 분석 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                SetAiLoadingState(false);
            }
        }

        private void ApplyAiResult(NaturalExpenseResult result)
        {
            textTitle.Text = result.Title;
            textAmount.Text = result.Amount > 0 ? result.Amount.ToString() : "";
            SelectComboItem(comboCategory, result.Category);
            SelectComboItem(comboPaymentMethod, result.PaymentMethod);
            textMemo.Text = result.Memo;

            if (DateTime.TryParse(result.ExpenseDate, out DateTime expenseDate))
            {
                dateExpense.Value = expenseDate;
            }
        }

        private static void SelectComboItem(ComboBox comboBox, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            int index = comboBox.FindStringExact(value.Trim());
            if (index >= 0)
            {
                comboBox.SelectedIndex = index;
            }
        }

        private void SetAiLoadingState(bool isLoading)
        {
            buttonAnalyzeAi.Enabled = !isLoading;
            buttonReceiptAi.Enabled = !isLoading;
            buttonAnalyzeAi.Text = isLoading ? "분석 중..." : "AI 분석";
            Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out int amount))
            {
                return;
            }

            var expense = new ExpenseItem
            {
                Title = textTitle.Text.Trim(),
                Amount = amount,
                Category = comboCategory.Text,
                PaymentMethod = comboPaymentMethod.Text,
                ExpenseDate = dateExpense.Value.Date,
                Memo = textMemo.Text.Trim(),
                IsFixed = checkIsFixed.Checked,
                CreatedAt = DateTime.Now
            };

            DatabaseHelper.AddExpense(expense);
            MessageBox.Show("지출 내역이 저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateInput(out int amount)
        {
            amount = 0;

            if (string.IsNullOrWhiteSpace(textTitle.Text))
            {
                MessageBox.Show("지출명을 입력해 주세요.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textTitle.Focus();
                return false;
            }

            if (!int.TryParse(textAmount.Text.Trim(), out amount) || amount <= 0)
            {
                MessageBox.Show("금액은 1원 이상의 숫자로 입력해 주세요.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textAmount.Focus();
                textAmount.SelectAll();
                return false;
            }

            return true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
