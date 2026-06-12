using ScheduleProject.Data;
using ScheduleProject.Models;

namespace ScheduleProject
{
    public partial class FormBudget : Form
    {
        private readonly string[] categories =
        {
            "식비",
            "교통",
            "쇼핑",
            "문화",
            "생활",
            "통신",
            "기타"
        };

        public FormBudget()
        {
            InitializeComponent();
            SetupGrid();
            comboCategory.Items.AddRange(categories);
            comboCategory.SelectedIndex = 0;
            dateBudgetMonth.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            LoadBudgets();
        }

        private void SetupGrid()
        {
            dgvBudgets.AutoGenerateColumns = false;
            dgvBudgets.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(241, 245, 249),
                Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129),
                ForeColor = Color.FromArgb(51, 65, 85),
                SelectionBackColor = Color.FromArgb(241, 245, 249),
                SelectionForeColor = Color.FromArgb(51, 65, 85)
            };
            dgvBudgets.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("맑은 고딕", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 129),
                ForeColor = Color.FromArgb(30, 41, 59),
                SelectionBackColor = Color.FromArgb(219, 234, 254),
                SelectionForeColor = Color.FromArgb(30, 64, 175),
                Padding = new Padding(6, 0, 0, 0)
            };
            dgvBudgets.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBudgets.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBudgets.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "colType",
                    HeaderText = "구분",
                    DataPropertyName = "Type",
                    Width = 140,
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colAmount",
                    HeaderText = "예산 금액",
                    DataPropertyName = "DisplayAmount",
                    Width = 180,
                    ReadOnly = true
                }
            });
        }

        private void LoadBudgets()
        {
            int year = dateBudgetMonth.Value.Year;
            int month = dateBudgetMonth.Value.Month;
            int monthlyExpense = DatabaseHelper.GetMonthlyExpenseAmount(year, month);
            int monthlyBudget = DatabaseHelper.GetMonthlyBudget(year, month);
            var categoryBudgets = DatabaseHelper.GetCategoryBudgets(year, month);
            var budgets = DatabaseHelper.GetMonthlyBudgets(year, month);

            textMonthlyBudget.Text = monthlyBudget > 0 ? monthlyBudget.ToString() : "";
            lblMonthSummaryValue.Text = FormatCurrency(monthlyBudget);
            lblExpenseSummaryValue.Text = FormatCurrency(monthlyExpense);
            lblRemainSummaryValue.Text = monthlyBudget > 0
                ? FormatCurrency(monthlyBudget - monthlyExpense)
                : "미설정";
            lblCategorySummaryValue.Text = FormatCurrency(categoryBudgets.Values.Sum());

            dgvBudgets.DataSource = budgets
                .OrderBy(b => string.IsNullOrWhiteSpace(b.Category) ? 0 : 1)
                .ThenBy(b => b.Category)
                .Select(b => new
                {
                    Type = string.IsNullOrWhiteSpace(b.Category) ? "전체 예산" : b.Category,
                    DisplayAmount = FormatCurrency(b.Amount)
                })
                .ToList();
        }

        private void buttonSaveMonthly_Click(object sender, EventArgs e)
        {
            if (!TryReadAmount(textMonthlyBudget, "전체 예산", out int amount))
            {
                return;
            }

            SaveBudget("", amount);
            MessageBox.Show("월 전체 예산을 저장했습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadBudgets();
        }

        private void buttonSaveCategory_Click(object sender, EventArgs e)
        {
            if (!TryReadAmount(textCategoryBudget, "카테고리 예산", out int amount))
            {
                return;
            }

            SaveBudget(comboCategory.Text, amount);
            MessageBox.Show("카테고리 예산을 저장했습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textCategoryBudget.Clear();
            LoadBudgets();
        }

        private void SaveBudget(string category, int amount)
        {
            DatabaseHelper.SaveBudget(new BudgetItem
            {
                Year = dateBudgetMonth.Value.Year,
                Month = dateBudgetMonth.Value.Month,
                Category = category,
                Amount = amount,
                CreatedAt = DateTime.Now
            });
        }

        private bool TryReadAmount(TextBox textBox, string label, out int amount)
        {
            string raw = textBox.Text.Replace(",", "").Trim();
            if (!int.TryParse(raw, out amount) || amount <= 0)
            {
                MessageBox.Show($"{label}은 1원 이상 숫자로 입력해 주세요.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus();
                textBox.SelectAll();
                return false;
            }

            return true;
        }

        private void dateBudgetMonth_ValueChanged(object sender, EventArgs e)
        {
            dateBudgetMonth.Value = new DateTime(dateBudgetMonth.Value.Year, dateBudgetMonth.Value.Month, 1);
            LoadBudgets();
        }

        private void buttonRefresh_Click(object sender, EventArgs e) => LoadBudgets();

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private static string FormatCurrency(int amount)
        {
            return amount.ToString("N0") + "원";
        }
    }
}
