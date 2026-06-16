using ScheduleProject.Data;

namespace ScheduleProject
{
    public partial class FormStats : Form
    {
        public FormStats()
        {
            InitializeComponent();
            SetupGrid();
            LoadStats();
        }

        private void SetupGrid()
        {
            dgvCategory.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(241, 245, 249),
                Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129),
                ForeColor = Color.FromArgb(51, 65, 85),
                SelectionBackColor = Color.FromArgb(241, 245, 249),
                SelectionForeColor = Color.FromArgb(51, 65, 85)
            };
            dgvCategory.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129),
                ForeColor = Color.FromArgb(30, 41, 59),
                SelectionBackColor = Color.FromArgb(219, 234, 254),
                SelectionForeColor = Color.FromArgb(30, 64, 175),
                Padding = new Padding(4, 0, 0, 0)
            };
            dgvCategory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvCategory.AutoGenerateColumns = false;
            dgvCategory.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { HeaderText = "카테고리", DataPropertyName = "Category", Width = 160, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "지출 금액",  DataPropertyName = "Amount",   Width = 160, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "비율",       DataPropertyName = "Ratio",    Width = 100, ReadOnly = true },
            });
        }

        private void LoadStats()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            lblTotalCountValue.Text   = DatabaseHelper.GetTotalExpenseCount().ToString("N0") + "건";
            lblTotalAmountValue.Text  = DatabaseHelper.GetTotalExpenseAmount().ToString("N0") + "원";
            lblMonthlyAmountValue.Text = DatabaseHelper.GetMonthlyExpenseAmount(year, month).ToString("N0") + "원";
            lblAverageAmountValue.Text = DatabaseHelper.GetAverageExpenseAmount().ToString("N0") + "원";

            var categoryStats = DatabaseHelper.GetCategoryExpenseSummary();
            int total = categoryStats.Values.Sum();

            dgvCategory.DataSource = categoryStats
                .Select(x => new
                {
                    Category = x.Key,
                    Amount   = x.Value.ToString("N0") + "원",
                    Ratio    = total > 0 ? (x.Value * 100.0 / total).ToString("F1") + "%" : "0%"
                }).ToList();
        }

        private void buttonRefresh_Click(object sender, EventArgs e) => LoadStats();

        private void buttonClose_Click(object sender, EventArgs e) => Close();
    }
}
