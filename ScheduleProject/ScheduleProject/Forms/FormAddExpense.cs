using ScheduleProject.Data;
using ScheduleProject.Models;

namespace ScheduleProject
{
    public partial class FormAddExpense : Form
    {
        public FormAddExpense()
        {
            InitializeComponent();
            comboCategory.SelectedIndex = 0;
            comboPaymentMethod.SelectedIndex = 0;
            dateExpense.Value = DateTime.Today;
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

        private void ClearInput()
        {
            textTitle.Clear();
            textAmount.Clear();
            comboCategory.SelectedIndex = 0;
            comboPaymentMethod.SelectedIndex = 0;
            dateExpense.Value = DateTime.Today;
            textMemo.Clear();
            checkIsFixed.Checked = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblCategory_Click(object sender, EventArgs e)
        {

        }

        private void textTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
