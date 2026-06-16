using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScheduleProject.Data;
using ScheduleProject.Models;

namespace ScheduleProject.Forms
{
    public partial class FormExpenseList : Form
    {
        private readonly Color pageBackColor = Color.FromArgb(248, 250, 252);
        private readonly Color panelBackColor = Color.White;
        private readonly Color borderColor = Color.FromArgb(203, 213, 225);
        private readonly Color primaryColor = Color.FromArgb(37, 99, 235);
        private readonly Color textColor = Color.FromArgb(17, 24, 39);
        private readonly Color mutedTextColor = Color.FromArgb(100, 116, 139);

        private List<ExpenseItem> currentExpenses = new();

        public FormExpenseList()
        {
            InitializeComponent();

            this.Size = new Size(1100, 700);
            this.MinimumSize = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            ApplyCustomStyles();
            WireEvents();
            LoadAllExpenses();
        }

        private void ApplyCustomStyles()
        {
            this.BackColor = pageBackColor;

            lblTitle.ForeColor = textColor;
            lblSubtitle.ForeColor = mutedTextColor;

            panelFilters.BackColor = panelBackColor;

            comboCategory.Items.Clear();
            comboCategory.Items.AddRange(new object[] { "카테고리: 전체", "식비", "교통", "쇼핑", "문화", "생활", "통신", "기타" });
            comboCategory.SelectedIndex = 0;

            comboPaymentMethod.Items.Clear();
            comboPaymentMethod.Items.AddRange(new object[] { "결제수단: 전체", "카드", "현금", "계좌이체", "간편결제", "기타" });
            comboPaymentMethod.SelectedIndex = 0;

            ConfigurePrimaryButton(btnSearch, "검색하기");
            ConfigureSecondaryButton(btnAll, "전체 내역");
            ConfigureSecondaryButton(btnToday, "오늘 지출");
            ConfigureSecondaryButton(btnThisMonth, "이번 달");
            ConfigureSecondaryButton(btnDateSearch, "날짜 검색");
            ConfigureSecondaryButton(btnImportCsv, "CSV 가져오기");
            ConfigureSecondaryButton(btnExportCsv, "CSV 내보내기");

            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvExpenses.AutoGenerateColumns = false;
            dgvExpenses.EnableHeadersVisualStyles = false;
            dgvExpenses.ColumnHeadersVisible = false; // Hide the header row (id, date, title etc.)
            dgvExpenses.GridColor = Color.FromArgb(226, 232, 240);
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.ReadOnly = true;

            dgvExpenses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvExpenses.DefaultCellStyle.SelectionForeColor = textColor;

            dgvExpenses.Columns.Clear();
            AddGridColumn(nameof(ExpenseListRow.Id), "번호", 55);
            AddGridColumn(nameof(ExpenseListRow.Date), "날짜", 95);
            AddGridColumn(nameof(ExpenseListRow.Title), "지출명", 160);
            AddGridColumn(nameof(ExpenseListRow.Amount), "금액", 100, DataGridViewContentAlignment.MiddleRight, "N0");
            AddGridColumn(nameof(ExpenseListRow.Category), "카테고리", 95);
            AddGridColumn(nameof(ExpenseListRow.PaymentMethod), "결제수단", 95);
            AddGridColumn(nameof(ExpenseListRow.Fixed), "고정", 60);
            AddGridColumn(nameof(ExpenseListRow.Memo), "메모", 230);
        }

        private void WireEvents()
        {
            btnAll.Click += (_, _) => LoadAllExpenses();
            btnSearch.Click += (_, _) => ApplySearchAndFilters();
            btnToday.Click += (_, _) => LoadDateExpenses(DateTime.Today, "오늘 지출");
            btnDateSearch.Click += (_, _) => LoadDateExpenses(dateFilter.Value.Date, "선택 날짜 지출");
            btnThisMonth.Click += (_, _) => LoadThisMonthExpenses();
            btnExportCsv.Click += (_, _) => ExportCsv();
            btnImportCsv.Click += (_, _) => ImportCsv();
            txtKeyword.KeyDown += TxtKeyword_KeyDown;
        }

        private void LoadAllExpenses()
        {
            try
            {
                BindExpenses(DatabaseHelper.GetAllExpenses(), "전체 지출 내역");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void LoadDateExpenses(DateTime date, string label)
        {
            try
            {
                BindExpenses(DatabaseHelper.GetExpensesByDate(date), $"{label}: {date:yyyy-MM-dd}");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void LoadThisMonthExpenses()
        {
            try
            {
                var now = DateTime.Now;
                BindExpenses(DatabaseHelper.GetThisMonthExpenses(now.Year, now.Month), $"이번 달 지출: {now:yyyy-MM}");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ApplySearchAndFilters()
        {
            try
            {
                string keyword = txtKeyword.Text.Trim();
                string? category = comboCategory.SelectedIndex > 0 ? comboCategory.Text.Replace("카테고리: ", "") : null;
                if (category != null && comboCategory.Text.StartsWith("카테고리: ")) category = comboCategory.Text.Substring(7);

                string? paymentMethod = comboPaymentMethod.SelectedIndex > 0 ? comboPaymentMethod.Text.Replace("결제수단: ", "") : null;
                if (paymentMethod != null && comboPaymentMethod.Text.StartsWith("결제수단: ")) paymentMethod = comboPaymentMethod.Text.Substring(7);

                var expenses = DatabaseHelper.SearchExpenses(keyword, category, paymentMethod);

                BindExpenses(expenses, BuildFilterStatus(keyword, category, paymentMethod));

                if (expenses.Count == 0)
                {
                    MessageBox.Show("조건에 맞는 지출 내역이 없습니다.", "검색 결과", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ExportCsv()
        {
            if (currentExpenses.Count == 0)
            {
                MessageBox.Show("내보낼 지출 내역이 없습니다.", "CSV 내보내기", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dialog = new SaveFileDialog
            {
                Filter = "CSV 파일 (*.csv)|*.csv",
                FileName = $"MoneyNote_Expenses_{DateTime.Now:yyyyMMdd}.csv"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                CsvService.ExportExpenses(currentExpenses, dialog.FileName);
                MessageBox.Show("CSV 파일로 내보냈습니다.", "CSV 내보내기", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ImportCsv()
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "CSV 파일 (*.csv)|*.csv"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                var importedExpenses = CsvService.ImportExpenses(dialog.FileName);

                foreach (var expense in importedExpenses)
                {
                    DatabaseHelper.AddExpense(expense);
                }

                LoadAllExpenses();
                MessageBox.Show($"{importedExpenses.Count}건의 지출을 가져왔습니다.", "CSV 가져오기", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void BindExpenses(List<ExpenseItem> expenses, string status)
        {
            currentExpenses = expenses;

            dgvExpenses.DataSource = null;
            dgvExpenses.DataSource = currentExpenses
                .Select(expense => new ExpenseListRow
                {
                    Id = expense.Id,
                    Date = expense.ExpenseDate.ToString("yyyy-MM-dd"),
                    Title = expense.Title,
                    Amount = expense.Amount,
                    Category = expense.Category,
                    PaymentMethod = expense.PaymentMethod,
                    Fixed = expense.IsFixed ? "예" : "아니오",
                    Memo = expense.Memo
                })
                .ToList();
        }

        private void AddGridColumn(
            string propertyName,
            string headerText,
            float fillWeight,
            DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleLeft,
            string? format = null)
        {
            var column = new DataGridViewTextBoxColumn
            {
                Name = propertyName,
                DataPropertyName = propertyName,
                HeaderText = headerText,
                FillWeight = fillWeight,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            column.DefaultCellStyle.Alignment = alignment;

            if (!string.IsNullOrWhiteSpace(format))
            {
                column.DefaultCellStyle.Format = format;
            }

            dgvExpenses.Columns.Add(column);
        }

        private string BuildFilterStatus(string keyword, string? category, string? paymentMethod)
        {
            var filters = new List<string>();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                filters.Add($"검색어 '{keyword}'");
            }

            if (category != null)
            {
                filters.Add($"카테고리 '{category}'");
            }

            if (paymentMethod != null)
            {
                filters.Add($"결제수단 '{paymentMethod}'");
            }

            return filters.Count == 0 ? "전체 지출" : string.Join(", ", filters);
        }

        private void TxtKeyword_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ApplySearchAndFilters();
            }
        }

        private void ConfigurePrimaryButton(Button button, string text)
        {
            button.Text = text;
            button.BackColor = primaryColor;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            button.ForeColor = Color.White;
            button.UseVisualStyleBackColor = false;
        }

        private void ConfigureSecondaryButton(Button button, string text)
        {
            button.Text = text;
            button.BackColor = Color.White;
            button.FlatAppearance.BorderColor = borderColor;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 232, 240);
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            button.ForeColor = Color.FromArgb(51, 65, 85);
            button.UseVisualStyleBackColor = false;
        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private sealed class ExpenseListRow
        {
            public int Id { get; set; }
            public string Date { get; set; } = "";
            public string Title { get; set; } = "";
            public int Amount { get; set; }
            public string Category { get; set; } = "";
            public string PaymentMethod { get; set; } = "";
            public string Fixed { get; set; } = "";
            public string Memo { get; set; } = "";
        }

        private void FormExpenseList_Load(object sender, EventArgs e)
        {

        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvExpenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
