using ScheduleProject.Data;
using ScheduleProject.Models;

namespace ScheduleProject.Forms
{
    public class FormEditExpense : Form
    {
        private readonly ExpenseItem expense;
        private readonly TextBox textTitle = new();
        private readonly TextBox textAmount = new();
        private readonly ComboBox comboCategory = new();
        private readonly ComboBox comboPaymentMethod = new();
        private readonly DateTimePicker dateExpense = new();
        private readonly TextBox textMemo = new();
        private readonly CheckBox checkIsFixed = new();
        private readonly Button buttonSave = new();
        private readonly Button buttonCancel = new();

        public FormEditExpense(ExpenseItem expense)
        {
            this.expense = expense;
            BuildUi();
            LoadExpense();
        }

        private void BuildUi()
        {
            Text = "MoneyNote - 지출 수정";
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(665, 565);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            var lblTitle = new Label
            {
                AutoSize = true,
                Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(42, 28),
                Text = "지출 수정"
            };

            var lblSubtitle = new Label
            {
                AutoSize = true,
                Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(46, 86),
                Text = "선택한 지출 내역의 금액, 카테고리, 결제수단, 메모를 수정합니다."
            };

            var panelInput = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(44, 126),
                Size = new Size(577, 320)
            };

            AddLabel(panelInput, "지출명", new Point(32, 24));
            textTitle.BorderStyle = BorderStyle.FixedSingle;
            textTitle.Font = new Font("맑은 고딕", 10F);
            textTitle.Location = new Point(32, 50);
            textTitle.Size = new Size(510, 25);

            AddLabel(panelInput, "금액", new Point(32, 92));
            textAmount.BorderStyle = BorderStyle.FixedSingle;
            textAmount.Font = new Font("맑은 고딕", 10F);
            textAmount.Location = new Point(32, 118);
            textAmount.Size = new Size(225, 25);

            AddLabel(panelInput, "카테고리", new Point(304, 92));
            comboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategory.Font = new Font("맑은 고딕", 10F);
            comboCategory.Items.AddRange(new object[] { "식비", "교통", "쇼핑", "문화", "생활", "통신", "기타" });
            comboCategory.Location = new Point(304, 118);
            comboCategory.Size = new Size(238, 25);

            AddLabel(panelInput, "결제 수단", new Point(32, 160));
            comboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPaymentMethod.Font = new Font("맑은 고딕", 10F);
            comboPaymentMethod.Items.AddRange(new object[] { "카드", "현금", "계좌이체", "간편결제", "기타" });
            comboPaymentMethod.Location = new Point(32, 186);
            comboPaymentMethod.Size = new Size(225, 25);

            AddLabel(panelInput, "지출 날짜", new Point(304, 160));
            dateExpense.Font = new Font("맑은 고딕", 10F);
            dateExpense.Format = DateTimePickerFormat.Short;
            dateExpense.Location = new Point(304, 186);
            dateExpense.Size = new Size(238, 25);

            AddLabel(panelInput, "메모", new Point(32, 226));
            textMemo.BorderStyle = BorderStyle.FixedSingle;
            textMemo.Font = new Font("맑은 고딕", 10F);
            textMemo.Location = new Point(32, 250);
            textMemo.Multiline = true;
            textMemo.Size = new Size(510, 34);

            checkIsFixed.AutoSize = true;
            checkIsFixed.Font = new Font("맑은 고딕", 10F);
            checkIsFixed.ForeColor = Color.FromArgb(51, 65, 85);
            checkIsFixed.Location = new Point(32, 290);
            checkIsFixed.Text = "매달 반복되는 고정 지출";

            panelInput.Controls.AddRange(new Control[]
            {
                textTitle,
                textAmount,
                comboCategory,
                comboPaymentMethod,
                dateExpense,
                textMemo,
                checkIsFixed
            });

            ConfigurePrimaryButton(buttonSave, "수정 저장", new Point(430, 486), new Size(110, 36));
            buttonSave.Click += buttonSave_Click;
            ConfigureSecondaryButton(buttonCancel, "닫기", new Point(548, 486), new Size(73, 36));
            buttonCancel.Click += (_, _) => Close();

            Controls.AddRange(new Control[] { lblTitle, lblSubtitle, panelInput, buttonSave, buttonCancel });
        }

        private static void AddLabel(Control parent, string text, Point location)
        {
            parent.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("맑은 고딕", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = location,
                Text = text
            });
        }

        private static void ConfigurePrimaryButton(Button button, string text, Point location, Size size)
        {
            button.Text = text;
            button.Location = location;
            button.Size = size;
            button.BackColor = Color.FromArgb(37, 99, 235);
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            button.ForeColor = Color.White;
            button.UseVisualStyleBackColor = false;
        }

        private static void ConfigureSecondaryButton(Button button, string text, Point location, Size size)
        {
            button.Text = text;
            button.Location = location;
            button.Size = size;
            button.BackColor = Color.White;
            button.FlatAppearance.BorderColor = Color.FromArgb(148, 163, 184);
            button.FlatAppearance.BorderSize = 2;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            button.ForeColor = Color.FromArgb(51, 65, 85);
            button.UseVisualStyleBackColor = false;
        }

        private void LoadExpense()
        {
            textTitle.Text = expense.Title;
            textAmount.Text = expense.Amount.ToString();
            SelectComboItem(comboCategory, expense.Category);
            SelectComboItem(comboPaymentMethod, expense.PaymentMethod);
            dateExpense.Value = expense.ExpenseDate;
            textMemo.Text = expense.Memo;
            checkIsFixed.Checked = expense.IsFixed;
        }

        private static void SelectComboItem(ComboBox comboBox, string value)
        {
            int index = comboBox.FindStringExact(value);
            comboBox.SelectedIndex = index >= 0 ? index : 0;
        }

        private void buttonSave_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(out int amount))
            {
                return;
            }

            expense.Title = textTitle.Text.Trim();
            expense.Amount = amount;
            expense.Category = comboCategory.Text;
            expense.PaymentMethod = comboPaymentMethod.Text;
            expense.ExpenseDate = dateExpense.Value.Date;
            expense.Memo = textMemo.Text.Trim();
            expense.IsFixed = checkIsFixed.Checked;
            expense.FixedExpenseRefId = checkIsFixed.Checked ? expense.FixedExpenseRefId : null;

            if (expense.IsFixed)
            {
                expense.FixedExpenseRefId = DatabaseHelper.SaveFixedExpenseFromExpense(expense);
            }

            DatabaseHelper.UpdateExpense(expense);
            MessageBox.Show("지출 내역을 수정했습니다.", "수정 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
