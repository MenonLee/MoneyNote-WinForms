using System.Drawing;
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

        private readonly Label lblTitle = new();
        private readonly Label lblSubtitle = new();
        private readonly Panel panelFilters = new();
        private readonly Panel panelSummary = new();
        private readonly TextBox txtKeyword = new();
        private readonly ComboBox comboCategory = new();
        private readonly ComboBox comboPaymentMethod = new();
        private readonly DateTimePicker dateFilter = new();
        private readonly Button btnSearch = new();
        private readonly Button btnAll = new();
        private readonly Button btnToday = new();
        private readonly Button btnDateSearch = new();
        private readonly Button btnThisMonth = new();
        private readonly Button btnExportCsv = new();
        private readonly Button btnImportCsv = new();
        private readonly DataGridView dgvExpenses = new();
        private readonly Label lblCount = new();
        private readonly Label lblTotalAmount = new();
        private readonly Label lblFilterStatus = new();

        private List<ExpenseItem> currentExpenses = new();

        public FormExpenseList()
        {
            InitializeComponent();
            BuildUi();
            WireEvents();
            LoadAllExpenses();
        }

        private void BuildUi()
        {
            Text = "MoneyNote - 지출 목록";
            BackColor = pageBackColor;
            ClientSize = new Size(1184, 631);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Font = new Font("맑은 고딕", 9F);

            lblTitle.Text = "지출 목록";
            lblTitle.Font = new Font("맑은 고딕", 24F, FontStyle.Bold);
            lblTitle.ForeColor = textColor;
            lblTitle.Location = new Point(44, 34);
            lblTitle.AutoSize = true;

            lblSubtitle.Text = "등록된 지출을 조회하고, 조건별로 필터링하거나 CSV 파일로 백업합니다.";
            lblSubtitle.Font = new Font("맑은 고딕", 10F);
            lblSubtitle.ForeColor = mutedTextColor;
            lblSubtitle.Location = new Point(48, 88);
            lblSubtitle.AutoSize = true;

            ConfigurePanel(panelFilters, new Point(48, 126), new Size(1088, 122));
            ConfigurePanel(panelSummary, new Point(48, 266), new Size(1088, 74));

            BuildFilters();
            BuildSummary();
            BuildGrid();

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);
            Controls.Add(panelFilters);
            Controls.Add(panelSummary);
            Controls.Add(dgvExpenses);
        }

        private void BuildFilters()
        {
            var lblKeyword = CreateCaption("검색어", 24, 18);
            txtKeyword.Location = new Point(24, 45);
            txtKeyword.Size = new Size(230, 28);
            txtKeyword.PlaceholderText = "지출명, 카테고리, 메모";

            var lblCategory = CreateCaption("카테고리", 274, 18);
            comboCategory.Location = new Point(274, 45);
            comboCategory.Size = new Size(145, 28);
            comboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategory.Items.AddRange(new object[] { "전체", "식비", "교통", "쇼핑", "문화", "생활", "통신", "기타" });
            comboCategory.SelectedIndex = 0;

            var lblPayment = CreateCaption("결제수단", 439, 18);
            comboPaymentMethod.Location = new Point(439, 45);
            comboPaymentMethod.Size = new Size(145, 28);
            comboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPaymentMethod.Items.AddRange(new object[] { "전체", "카드", "현금", "계좌이체", "간편결제", "기타" });
            comboPaymentMethod.SelectedIndex = 0;

            var lblDate = CreateCaption("날짜", 604, 18);
            dateFilter.Location = new Point(604, 45);
            dateFilter.Size = new Size(145, 28);
            dateFilter.Format = DateTimePickerFormat.Short;

            ConfigurePrimaryButton(btnSearch, "검색", new Point(772, 43), new Size(82, 32));
            ConfigureSecondaryButton(btnAll, "전체", new Point(862, 43), new Size(72, 32));
            ConfigureSecondaryButton(btnToday, "오늘", new Point(942, 43), new Size(72, 32));
            ConfigureSecondaryButton(btnDateSearch, "날짜", new Point(1022, 43), new Size(72, 32));
            ConfigureSecondaryButton(btnThisMonth, "이번 달", new Point(24, 82), new Size(90, 30));
            ConfigureSecondaryButton(btnExportCsv, "CSV 내보내기", new Point(124, 82), new Size(120, 30));
            ConfigureSecondaryButton(btnImportCsv, "CSV 가져오기", new Point(254, 82), new Size(120, 30));

            panelFilters.Controls.AddRange(new Control[]
            {
                lblKeyword, txtKeyword, lblCategory, comboCategory, lblPayment, comboPaymentMethod,
                lblDate, dateFilter, btnSearch, btnAll, btnToday, btnDateSearch,
                btnThisMonth, btnExportCsv, btnImportCsv
            });
        }

        private void BuildSummary()
        {
            lblCount.Font = new Font("맑은 고딕", 13F, FontStyle.Bold);
            lblCount.ForeColor = textColor;
            lblCount.Location = new Point(24, 14);
            lblCount.Size = new Size(220, 26);

            lblTotalAmount.Font = new Font("맑은 고딕", 13F, FontStyle.Bold);
            lblTotalAmount.ForeColor = primaryColor;
            lblTotalAmount.Location = new Point(260, 14);
            lblTotalAmount.Size = new Size(280, 26);

            lblFilterStatus.Font = new Font("맑은 고딕", 9F);
            lblFilterStatus.ForeColor = mutedTextColor;
            lblFilterStatus.Location = new Point(24, 45);
            lblFilterStatus.Size = new Size(1000, 20);

            panelSummary.Controls.AddRange(new Control[] { lblCount, lblTotalAmount, lblFilterStatus });
        }

        private void BuildGrid()
        {
            dgvExpenses.Location = new Point(48, 358);
            dgvExpenses.Size = new Size(1088, 224);
            dgvExpenses.BackgroundColor = Color.White;
            dgvExpenses.BorderStyle = BorderStyle.FixedSingle;
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.AllowUserToDeleteRows = false;
            dgvExpenses.AllowUserToResizeRows = false;
            dgvExpenses.AutoGenerateColumns = false;
            dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpenses.ColumnHeadersHeight = 34;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvExpenses.EnableHeadersVisualStyles = false;
            dgvExpenses.GridColor = Color.FromArgb(226, 232, 240);
            dgvExpenses.MultiSelect = false;
            dgvExpenses.ReadOnly = true;
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.RowTemplate.Height = 30;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvExpenses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvExpenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvExpenses.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            dgvExpenses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvExpenses.DefaultCellStyle.SelectionForeColor = textColor;

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
            comboCategory.SelectedIndexChanged += (_, _) => ApplySearchAndFilters();
            comboPaymentMethod.SelectedIndexChanged += (_, _) => ApplySearchAndFilters();
        }

        private void LoadAllExpenses()
        {
            try
            {
                BindExpenses(DatabaseHelper.GetAllExpenses(), "전체 지출");
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
                var expenses = string.IsNullOrWhiteSpace(keyword)
                    ? DatabaseHelper.GetAllExpenses()
                    : DatabaseHelper.SearchExpenses(keyword);

                if (comboCategory.SelectedIndex > 0)
                {
                    expenses = expenses
                        .Where(expense => expense.Category == comboCategory.Text)
                        .ToList();
                }

                if (comboPaymentMethod.SelectedIndex > 0)
                {
                    expenses = expenses
                        .Where(expense => expense.PaymentMethod == comboPaymentMethod.Text)
                        .ToList();
                }

                BindExpenses(expenses, BuildFilterStatus(keyword));

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
                .Select(expense => new
                ExpenseListRow
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

            lblCount.Text = $"조회 건수: {currentExpenses.Count:N0}건";
            lblTotalAmount.Text = $"합계: {currentExpenses.Sum(expense => expense.Amount):N0}원";
            lblFilterStatus.Text = status;
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

        private string BuildFilterStatus(string keyword)
        {
            var filters = new List<string>();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                filters.Add($"검색어 '{keyword}'");
            }

            if (comboCategory.SelectedIndex > 0)
            {
                filters.Add($"카테고리 '{comboCategory.Text}'");
            }

            if (comboPaymentMethod.SelectedIndex > 0)
            {
                filters.Add($"결제수단 '{comboPaymentMethod.Text}'");
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

        private Label CreateCaption(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Font = new Font("맑은 고딕", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(x, y),
                AutoSize = true
            };
        }

        private void ConfigurePanel(Panel panel, Point location, Size size)
        {
            panel.BackColor = panelBackColor;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Location = location;
            panel.Size = size;
        }

        private void ConfigurePrimaryButton(Button button, string text, Point location, Size size)
        {
            button.Text = text;
            button.Location = location;
            button.Size = size;
            button.BackColor = primaryColor;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            button.ForeColor = Color.White;
            button.UseVisualStyleBackColor = false;
        }

        private void ConfigureSecondaryButton(Button button, string text, Point location, Size size)
        {
            button.Text = text;
            button.Location = location;
            button.Size = size;
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
    }
}
