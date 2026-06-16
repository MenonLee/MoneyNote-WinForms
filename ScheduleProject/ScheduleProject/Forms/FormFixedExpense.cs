using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ScheduleProject.Data;
using ScheduleProject.Models;

namespace ScheduleProject.Forms
{
    public partial class FormFixedExpense : Form
    {
        public FormFixedExpense()
        {
            InitializeComponent();
            this.Load += FormFixedExpense_Load;
            this.dgvFixedExpenses.SelectionChanged += DgvFixedExpenses_SelectionChanged;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnUpdate.Click += BtnUpdate_Click;
            this.btnDelete.Click += BtnDelete_Click;
        }

        private void FormFixedExpense_Load(object sender, EventArgs e)
        {
            LoadFixedExpenses();
            // 기본값 설정
            cmbCategory.SelectedIndex = 0;
            cmbPayment.SelectedIndex = 0;
        }

        private void LoadFixedExpenses()
        {
            var list = DatabaseHelper.GetActiveFixedExpenses();
            dgvFixedExpenses.DataSource = null;
            dgvFixedExpenses.DataSource = list;

            if (dgvFixedExpenses.Columns.Count > 0)
            {
                if (dgvFixedExpenses.Columns["Id"] != null) dgvFixedExpenses.Columns["Id"].Visible = false;
                if (dgvFixedExpenses.Columns["Title"] != null) dgvFixedExpenses.Columns["Title"].HeaderText = "지출명";
                if (dgvFixedExpenses.Columns["Amount"] != null) dgvFixedExpenses.Columns["Amount"].HeaderText = "금액";
                if (dgvFixedExpenses.Columns["Category"] != null) dgvFixedExpenses.Columns["Category"].HeaderText = "카테고리";
                if (dgvFixedExpenses.Columns["PaymentMethod"] != null) dgvFixedExpenses.Columns["PaymentMethod"].HeaderText = "결제수단";
                if (dgvFixedExpenses.Columns["DayOfMonth"] != null) dgvFixedExpenses.Columns["DayOfMonth"].HeaderText = "발생일";
                if (dgvFixedExpenses.Columns["Memo"] != null) dgvFixedExpenses.Columns["Memo"].HeaderText = "메모";
                if (dgvFixedExpenses.Columns["IsActive"] != null) dgvFixedExpenses.Columns["IsActive"].HeaderText = "활성";
                if (dgvFixedExpenses.Columns["CreatedAt"] != null) dgvFixedExpenses.Columns["CreatedAt"].Visible = false;
            }
        }

        private void DgvFixedExpenses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFixedExpenses.SelectedRows.Count > 0)
            {
                var item = dgvFixedExpenses.SelectedRows[0].DataBoundItem as FixedExpenseItem;
                if (item != null)
                {
                    txtTitle.Text = item.Title;
                    numAmount.Value = item.Amount;
                    numDay.Value = item.DayOfMonth;
                    cmbCategory.SelectedItem = item.Category;
                    cmbPayment.SelectedItem = item.PaymentMethod;
                    txtMemo.Text = item.Memo;
                    chkIsActive.Checked = item.IsActive;
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("지출명을 입력해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numAmount.Value <= 0)
            {
                MessageBox.Show("금액을 0원보다 크게 입력해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var newItem = new FixedExpenseItem
            {
                Title = txtTitle.Text,
                Amount = (int)numAmount.Value,
                DayOfMonth = (int)numDay.Value,
                Category = cmbCategory.SelectedItem?.ToString() ?? "기타",
                PaymentMethod = cmbPayment.SelectedItem?.ToString() ?? "기타",
                Memo = txtMemo.Text,
                IsActive = chkIsActive.Checked,
                CreatedAt = DateTime.Now
            };

            DatabaseHelper.AddFixedExpense(newItem);
            MessageBox.Show("고정지출이 등록되었습니다.", "알림");
            LoadFixedExpenses();
            ClearInput();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvFixedExpenses.SelectedRows.Count == 0)
            {
                MessageBox.Show("수정할 항목을 목록에서 선택해 주세요.");
                return;
            }
            if (!ValidateInput()) return;

            var selectedItem = dgvFixedExpenses.SelectedRows[0].DataBoundItem as FixedExpenseItem;
            if (selectedItem == null) return;

            selectedItem.Title = txtTitle.Text;
            selectedItem.Amount = (int)numAmount.Value;
            selectedItem.DayOfMonth = (int)numDay.Value;
            selectedItem.Category = cmbCategory.SelectedItem?.ToString() ?? "기타";
            selectedItem.PaymentMethod = cmbPayment.SelectedItem?.ToString() ?? "기타";
            selectedItem.Memo = txtMemo.Text;
            selectedItem.IsActive = chkIsActive.Checked;

            DatabaseHelper.UpdateFixedExpense(selectedItem);
            MessageBox.Show("수정되었습니다.", "알림");
            LoadFixedExpenses();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFixedExpenses.SelectedRows.Count == 0)
            {
                MessageBox.Show("삭제할 항목을 목록에서 선택해 주세요.");
                return;
            }

            var selectedItem = dgvFixedExpenses.SelectedRows[0].DataBoundItem as FixedExpenseItem;
            if (selectedItem == null) return;

            if (MessageBox.Show($"'{selectedItem.Title}' 항목을 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DatabaseHelper.DeleteFixedExpense(selectedItem.Id);
                LoadFixedExpenses();
                ClearInput();
            }
        }

        private void ClearInput()
        {
            txtTitle.Clear();
            numAmount.Value = 0;
            numDay.Value = 1;
            cmbCategory.SelectedIndex = 0;
            cmbPayment.SelectedIndex = 0;
            txtMemo.Clear();
            chkIsActive.Checked = true;
        }
    }
}
