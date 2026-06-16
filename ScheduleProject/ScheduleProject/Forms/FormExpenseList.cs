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

        public bool HasImportedExpenses { get; private set; }
        public bool HasChangedExpenses { get; private set; }

        public FormExpenseList()
        {
            InitializeComponent();

            Size = new Size(1000, 630);
            MinimumSize = new Size(1000, 630);
            MaximumSize = new Size(1000, 630);
            StartPosition = FormStartPosition.CenterParent;

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
            panelFilters.Padding = new Padding(0);

            comboCategory.Items.Clear();
            comboCategory.Items.AddRange(new object[] { "카테고리: 전체", "식비", "교통", "쇼핑", "문화", "생활", "통신", "기타" });
            comboCategory.SelectedIndex = 0;
            comboCategory.Font = new Font("맑은 고딕", 9.5F);

            comboPaymentMethod.Items.Clear();
            comboPaymentMethod.Items.AddRange(new object[] { "결제수단: 전체", "카드", "현금", "계좌이체", "간편결제", "기타" });
            comboPaymentMethod.SelectedIndex = 0;
            comboPaymentMethod.Font = new Font("맑은 고딕", 9.5F);

            txtKeyword.Font = new Font("맑은 고딕", 9.5F);
            dateFilter.Font = new Font("맑은 고딕", 9.5F);

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
            dgvExpenses.ColumnHeadersVisible = true;
            dgvExpenses.ColumnHeadersHeight = 34;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvExpenses.GridColor = Color.FromArgb(226, 232, 240);
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.AllowUserToDeleteRows = false;
            dgvExpenses.AllowUserToResizeRows = false;
            dgvExpenses.ReadOnly = true;
            dgvExpenses.RowTemplate.Height = 32;
            dgvExpenses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvExpenses.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvExpenses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvExpenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvExpenses.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            dgvExpenses.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExpenses.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
            dgvExpenses.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);

            dgvExpenses.DefaultCellStyle.Font = new Font("맑은 고딕", 9.5F);
            dgvExpenses.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvExpenses.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExpenses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvExpenses.DefaultCellStyle.SelectionForeColor = textColor;
            dgvExpenses.DefaultCellStyle.Padding = new Padding(4, 0, 0, 0);

            dgvExpenses.Columns.Clear();
            AddGridColumn(nameof(ExpenseListRow.Date), "날짜", 100);
            AddGridColumn(nameof(ExpenseListRow.Title), "지출명", 170, DataGridViewContentAlignment.MiddleLeft, null, DataGridViewContentAlignment.MiddleLeft);
            AddGridColumn(nameof(ExpenseListRow.Amount), "금액", 95, DataGridViewContentAlignment.MiddleCenter, "N0");
            AddGridColumn(nameof(ExpenseListRow.Category), "카테고리", 85);
            AddGridColumn(nameof(ExpenseListRow.PaymentMethod), "결제수단", 95);
            AddGridColumn(nameof(ExpenseListRow.Fixed), "고정", 55, DataGridViewContentAlignment.MiddleCenter);
            AddGridColumn(nameof(ExpenseListRow.Memo), "메모", 190, DataGridViewContentAlignment.MiddleLeft, null, DataGridViewContentAlignment.MiddleLeft);
            AddButtonColumn("Edit", "수정", 60);
            AddButtonColumn("Delete", "삭제", 60);
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
            dgvExpenses.CellPainting += dgvExpenses_CellPainting;
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
                HasImportedExpenses = importedExpenses.Count > 0;
                HasChangedExpenses = importedExpenses.Count > 0;
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
                    Fixed = expense.IsFixed ? "O" : "X",
                    Memo = expense.Memo
                })
                .ToList();
        }

        private void AddGridColumn(
            string propertyName,
            string headerText,
            int width,
            DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleCenter,
            string? format = null,
            DataGridViewContentAlignment headerAlignment = DataGridViewContentAlignment.MiddleCenter)
        {
            var column = new DataGridViewTextBoxColumn
            {
                Name = propertyName,
                DataPropertyName = propertyName,
                HeaderText = headerText,
                Width = width,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            column.DefaultCellStyle.Alignment = alignment;
            column.HeaderCell.Style.Alignment = headerAlignment;

            if (!string.IsNullOrWhiteSpace(format))
            {
                column.DefaultCellStyle.Format = format;
            }

            dgvExpenses.Columns.Add(column);
        }

        private void AddButtonColumn(string name, string buttonText, int width)
        {
            var column = new DataGridViewButtonColumn
            {
                Name = name,
                HeaderText = "",
                Text = buttonText,
                UseColumnTextForButtonValue = true,
                Width = width,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                FlatStyle = FlatStyle.Flat
            };

            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            button.Cursor = Cursors.Hand;
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
            button.Cursor = Cursors.Hand;
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
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (dgvExpenses.Rows[e.RowIndex].DataBoundItem is not ExpenseListRow row)
            {
                return;
            }

            string columnName = dgvExpenses.Columns[e.ColumnIndex].Name;
            if (columnName == "Edit")
            {
                EditExpense(row.Id);
            }
            else if (columnName == "Delete")
            {
                DeleteExpense(row.Id, row.Title);
            }
        }

        private void dgvExpenses_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics == null)
            {
                return;
            }

            string columnName = dgvExpenses.Columns[e.ColumnIndex].Name;
            if (columnName != "Edit" && columnName != "Delete")
            {
                return;
            }

            e.PaintBackground(e.CellBounds, true);

            Rectangle buttonBounds = new Rectangle(
                e.CellBounds.X + 8,
                e.CellBounds.Y + 5,
                e.CellBounds.Width - 16,
                e.CellBounds.Height - 10);

            bool isEdit = columnName == "Edit";
            Color backColor = isEdit ? primaryColor : Color.White;
            Color borderColor = isEdit ? primaryColor : Color.FromArgb(148, 163, 184);
            Color textColor = isEdit ? Color.White : Color.FromArgb(51, 65, 85);
            string text = isEdit ? "수정" : "삭제";

            using var backgroundBrush = new SolidBrush(backColor);
            using var borderPen = new Pen(borderColor, 1);
            using var textBrush = new SolidBrush(textColor);

            e.Graphics.FillRectangle(backgroundBrush, buttonBounds);
            e.Graphics.DrawRectangle(borderPen, buttonBounds);

            TextRenderer.DrawText(
                e.Graphics,
                text,
                new Font("맑은 고딕", 8.5F, FontStyle.Bold),
                buttonBounds,
                textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            e.Handled = true;
        }

        private void EditExpense(int expenseId)
        {
            var expense = DatabaseHelper.GetExpenseById(expenseId);
            if (expense == null)
            {
                MessageBox.Show("선택한 지출 내역을 찾을 수 없습니다.", "수정 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadAllExpenses();
                return;
            }

            using var form = new FormEditExpense(expense);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                HasChangedExpenses = true;
                LoadAllExpenses();
            }
        }

        private void DeleteExpense(int expenseId, string title)
        {
            var result = MessageBox.Show(
                $"'{title}' 지출 내역을 삭제할까요?",
                "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            DatabaseHelper.DeleteExpense(expenseId);
            HasChangedExpenses = true;
            LoadAllExpenses();
        }
    }
}
