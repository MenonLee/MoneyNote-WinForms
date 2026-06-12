using ScheduleProject.Data;
using ScheduleProject.Models;

namespace ScheduleProject
{
    public partial class FormManageExpense : Form
    {
        private int _selectedId = -1;

        public FormManageExpense()
        {
            InitializeComponent();
            SetupGrid();
            LoadExpenses();
        }

        private void SetupGrid()
        {
            dgvExpenses.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(241, 245, 249),
                Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129),
                ForeColor = Color.FromArgb(51, 65, 85),
                SelectionBackColor = Color.FromArgb(241, 245, 249),
                SelectionForeColor = Color.FromArgb(51, 65, 85)
            };
            dgvExpenses.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("맑은 고딕", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 129),
                ForeColor = Color.FromArgb(30, 41, 59),
                SelectionBackColor = Color.FromArgb(219, 234, 254),
                SelectionForeColor = Color.FromArgb(30, 64, 175),
                Padding = new Padding(4, 0, 0, 0)
            };
            dgvExpenses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvExpenses.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvExpenses.AutoGenerateColumns = false;
            dgvExpenses.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "colId",       HeaderText = "번호",    DataPropertyName = "Id",            Width = 50,  ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colDate",     HeaderText = "날짜",    DataPropertyName = "DisplayDate",   Width = 95,  ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colTitle",    HeaderText = "지출명",  DataPropertyName = "Title",         Width = 120, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colCategory", HeaderText = "카테고리", DataPropertyName = "Category",     Width = 75,  ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colAmount",   HeaderText = "금액",    DataPropertyName = "DisplayAmount", Width = 100, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "colPayment",  HeaderText = "결제수단", DataPropertyName = "PaymentMethod", Width = 80,  ReadOnly = true },
            });
        }

        private void LoadExpenses()
        {
            dgvExpenses.SelectionChanged -= dgvExpenses_SelectionChanged;

            dgvExpenses.DataSource = DatabaseHelper.GetAllExpenses()
                .Select(e => new
                {
                    e.Id,
                    DisplayDate = e.ExpenseDate.ToString("yyyy-MM-dd"),
                    e.Title,
                    e.Category,
                    DisplayAmount = e.Amount.ToString("N0") + "원",
                    e.PaymentMethod
                }).ToList();

            dgvExpenses.SelectionChanged += dgvExpenses_SelectionChanged;
            ClearForm();
        }

        private void dgvExpenses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count == 0) return;

            var id = Convert.ToInt32(dgvExpenses.SelectedRows[0].Cells["colId"].Value);
            var expense = DatabaseHelper.GetExpenseById(id);
            if (expense == null) return;

            _selectedId = expense.Id;
            textTitle.Text = expense.Title;
            textAmount.Text = expense.Amount.ToString();
            comboCategory.Text = expense.Category;
            comboPaymentMethod.Text = expense.PaymentMethod;
            dateExpense.Value = expense.ExpenseDate;
            textMemo.Text = expense.Memo;
            checkIsFixed.Checked = expense.IsFixed;
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedId < 0) return;
            if (!ValidateInput(out int amount)) return;

            DatabaseHelper.UpdateExpense(new ExpenseItem
            {
                Id = _selectedId,
                Title = textTitle.Text.Trim(),
                Amount = amount,
                Category = comboCategory.Text,
                PaymentMethod = comboPaymentMethod.Text,
                ExpenseDate = dateExpense.Value.Date,
                Memo = textMemo.Text.Trim(),
                IsFixed = checkIsFixed.Checked
            });

            MessageBox.Show("지출 내역이 수정되었습니다.", "수정 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadExpenses();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId < 0) return;

            if (MessageBox.Show("선택한 지출 내역을 삭제하시겠습니까?", "삭제 확인",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            DatabaseHelper.DeleteExpense(_selectedId);
            MessageBox.Show("삭제되었습니다.", "삭제 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadExpenses();
        }

        private void buttonRefresh_Click(object sender, EventArgs e) => LoadExpenses();

        private void buttonClose_Click(object sender, EventArgs e) => Close();

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

        private void ClearForm()
        {
            _selectedId = -1;
            textTitle.Clear();
            textAmount.Clear();
            comboCategory.SelectedIndex = 0;
            comboPaymentMethod.SelectedIndex = 0;
            dateExpense.Value = DateTime.Today;
            textMemo.Clear();
            checkIsFixed.Checked = false;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
        }
    }
}
