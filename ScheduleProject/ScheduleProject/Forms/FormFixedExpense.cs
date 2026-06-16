using ScheduleProject.Data;
using ScheduleProject.Models;

namespace ScheduleProject.Forms
{
    public partial class FormFixedExpense : Form
    {
        private FixedExpenseItem? selectedFixedExpense;

        public FormFixedExpense()
        {
            InitializeComponent();
            Load += FormFixedExpense_Load;
            dgvFixedExpenses.SelectionChanged += DgvFixedExpenses_SelectionChanged;
            dgvFixedExpenses.CellContentClick += DgvFixedExpenses_CellContentClick;
            dgvFixedExpenses.MouseDown += DgvFixedExpenses_MouseDown;
            btnAdd.Click += BtnAdd_Click;
        }

        private void FormFixedExpense_Load(object? sender, EventArgs e)
        {
            SetupDayOptions();
            SetupGridStyle();
            LoadFixedExpenses();
            ClearInput();
        }

        private void SetupDayOptions()
        {
            cmbDay.Items.Clear();
            for (int day = 1; day <= 31; day++)
            {
                cmbDay.Items.Add(day.ToString());
            }
        }

        private void SetupGridStyle()
        {
            dgvFixedExpenses.AutoGenerateColumns = false;
            dgvFixedExpenses.Columns.Clear();
            dgvFixedExpenses.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(241, 245, 249),
                Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129),
                ForeColor = Color.FromArgb(51, 65, 85),
                SelectionBackColor = Color.FromArgb(241, 245, 249),
                SelectionForeColor = Color.FromArgb(51, 65, 85)
            };
            dgvFixedExpenses.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("맑은 고딕", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 129),
                ForeColor = Color.FromArgb(30, 41, 59),
                SelectionBackColor = Color.FromArgb(219, 234, 254),
                SelectionForeColor = Color.FromArgb(30, 64, 175),
                Padding = new Padding(6, 0, 6, 0)
            };
            dgvFixedExpenses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFixedExpenses.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvFixedExpenses.EnableHeadersVisualStyles = false;

            AddTextColumn(nameof(FixedExpenseItem.Title), "지출명", 150, DataGridViewContentAlignment.MiddleLeft);
            AddTextColumn(nameof(FixedExpenseItem.Amount), "금액", 105, DataGridViewContentAlignment.MiddleRight, "N0");
            AddTextColumn(nameof(FixedExpenseItem.DayOfMonth), "발생일", 75, DataGridViewContentAlignment.MiddleCenter);
            AddTextColumn(nameof(FixedExpenseItem.Category), "카테고리", 100, DataGridViewContentAlignment.MiddleCenter);
            AddTextColumn(nameof(FixedExpenseItem.PaymentMethod), "결제수단", 105, DataGridViewContentAlignment.MiddleCenter);
            AddTextColumn(nameof(FixedExpenseItem.Memo), "메모", 180, DataGridViewContentAlignment.MiddleLeft);
            AddDeleteButtonColumn();
            FitGridColumnsToCompactWidth();
        }

        private void FitGridColumnsToCompactWidth()
        {
            SetColumnWidth(nameof(FixedExpenseItem.Title), 130);
            SetColumnWidth(nameof(FixedExpenseItem.Amount), 90);
            SetColumnWidth(nameof(FixedExpenseItem.DayOfMonth), 65);
            SetColumnWidth(nameof(FixedExpenseItem.Category), 85);
            SetColumnWidth(nameof(FixedExpenseItem.PaymentMethod), 90);
            SetColumnWidth(nameof(FixedExpenseItem.Memo), 160);
            SetColumnWidth("DeleteAction", 60);
        }

        private void SetColumnWidth(string columnName, int width)
        {
            if (dgvFixedExpenses.Columns[columnName] is DataGridViewColumn column)
            {
                column.Width = width;
            }
        }

        private void AddTextColumn(string propertyName, string headerText, int width, DataGridViewContentAlignment alignment, string? format = null)
        {
            var column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = propertyName,
                HeaderText = headerText,
                Name = propertyName,
                ReadOnly = true,
                Width = width
            };
            column.DefaultCellStyle.Alignment = alignment;
            column.HeaderCell.Style.Alignment = alignment;

            if (!string.IsNullOrWhiteSpace(format))
            {
                column.DefaultCellStyle.Format = format;
            }

            dgvFixedExpenses.Columns.Add(column);
        }

        private void AddDeleteButtonColumn()
        {
            var column = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "DeleteAction",
                Text = "삭제",
                UseColumnTextForButtonValue = true,
                Width = 76,
                FlatStyle = FlatStyle.Popup
            };
            column.DefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            column.DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28);
            column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            column.DefaultCellStyle.SelectionForeColor = Color.FromArgb(185, 28, 28);
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.DefaultCellStyle.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            column.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            dgvFixedExpenses.Columns.Add(column);
        }

        private void LoadFixedExpenses()
        {
            dgvFixedExpenses.DataSource = null;
            dgvFixedExpenses.DataSource = DatabaseHelper.GetActiveFixedExpenses();
            dgvFixedExpenses.ClearSelection();
        }

        private void DgvFixedExpenses_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvFixedExpenses.SelectedRows.Count == 0)
            {
                return;
            }

            if (dgvFixedExpenses.SelectedRows[0].DataBoundItem is not FixedExpenseItem item)
            {
                return;
            }

            selectedFixedExpense = item;
            txtTitle.Text = item.Title;
            txtAmount.Text = item.Amount.ToString();
            SelectComboItem(cmbDay, item.DayOfMonth.ToString());
            SelectComboItem(cmbCategory, item.Category);
            SelectComboItem(cmbPayment, item.PaymentMethod);
            txtMemo.Text = item.Memo;
            chkIsActive.Checked = item.IsActive;
            btnAdd.Text = "수정";
        }

        private void DgvFixedExpenses_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string columnName = dgvFixedExpenses.Columns[e.ColumnIndex].Name;
            if (columnName != "DeleteAction")
            {
                return;
            }

            if (dgvFixedExpenses.Rows[e.RowIndex].DataBoundItem is not FixedExpenseItem selectedItem)
            {
                return;
            }

            dgvFixedExpenses.ClearSelection();
            dgvFixedExpenses.Rows[e.RowIndex].Selected = true;
            DeleteFixedExpense(selectedItem);
        }

        private void DgvFixedExpenses_MouseDown(object? sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dgvFixedExpenses.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.None ||
                hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                ClearInput();
            }
        }

        private bool ValidateInput(out int amount, out int dayOfMonth)
        {
            amount = 0;
            dayOfMonth = 1;

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("지출명을 입력해 주세요.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            string amountText = txtAmount.Text.Trim().Replace(",", "");
            if (!int.TryParse(amountText, out amount) || amount <= 0)
            {
                MessageBox.Show("금액은 1원 이상 숫자로 입력해 주세요.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                txtAmount.SelectAll();
                return false;
            }

            if (!int.TryParse(cmbDay.SelectedItem?.ToString(), out dayOfMonth) || dayOfMonth < 1 || dayOfMonth > 31)
            {
                MessageBox.Show("발생일을 선택해 주세요.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDay.Focus();
                return false;
            }

            return true;
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(out int amount, out int dayOfMonth))
            {
                return;
            }

            if (selectedFixedExpense != null)
            {
                UpdateFixedExpense(selectedFixedExpense, amount, dayOfMonth);
                return;
            }

            var newItem = new FixedExpenseItem
            {
                Title = txtTitle.Text.Trim(),
                Amount = amount,
                DayOfMonth = dayOfMonth,
                Category = cmbCategory.SelectedItem?.ToString() ?? "기타",
                PaymentMethod = cmbPayment.SelectedItem?.ToString() ?? "기타",
                Memo = txtMemo.Text.Trim(),
                IsActive = chkIsActive.Checked,
                CreatedAt = DateTime.Now
            };

            DatabaseHelper.AddFixedExpense(newItem);
            MessageBox.Show("고정지출이 등록되었습니다.", "등록 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadFixedExpenses();
            ClearInput();
        }

        private void UpdateFixedExpense(FixedExpenseItem selectedItem, int amount, int dayOfMonth)
        {
            selectedItem.Title = txtTitle.Text.Trim();
            selectedItem.Amount = amount;
            selectedItem.DayOfMonth = dayOfMonth;
            selectedItem.Category = cmbCategory.SelectedItem?.ToString() ?? "기타";
            selectedItem.PaymentMethod = cmbPayment.SelectedItem?.ToString() ?? "기타";
            selectedItem.Memo = txtMemo.Text.Trim();
            selectedItem.IsActive = chkIsActive.Checked;

            DatabaseHelper.UpdateFixedExpense(selectedItem);
            MessageBox.Show("고정지출이 수정되었습니다.", "수정 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadFixedExpenses();
            ClearInput();
        }

        private void DeleteFixedExpense(FixedExpenseItem selectedItem)
        {
            DialogResult result = MessageBox.Show(
                $"'{selectedItem.Title}' 항목을 삭제할까요?",
                "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            DatabaseHelper.DeleteFixedExpense(selectedItem.Id);
            LoadFixedExpenses();
            ClearInput();
        }

        private static void SelectComboItem(ComboBox comboBox, string value)
        {
            int index = comboBox.FindStringExact(value);
            if (index >= 0)
            {
                comboBox.SelectedIndex = index;
            }
        }

        private void ClearInput()
        {
            txtTitle.Clear();
            txtAmount.Clear();
            cmbDay.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            cmbPayment.SelectedIndex = 0;
            txtMemo.Clear();
            chkIsActive.Checked = true;
            selectedFixedExpense = null;
            btnAdd.Text = "등록";
            dgvFixedExpenses.ClearSelection();
        }
    }
}
