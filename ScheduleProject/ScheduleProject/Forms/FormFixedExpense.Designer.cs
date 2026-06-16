namespace ScheduleProject.Forms
{
    partial class FormFixedExpense
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubtitle = new Label();
            panelInput = new Panel();
            btnAdd = new Button();
            chkIsActive = new CheckBox();
            txtMemo = new TextBox();
            lblMemo = new Label();
            cmbPayment = new ComboBox();
            lblPayment = new Label();
            cmbCategory = new ComboBox();
            lblCategory = new Label();
            cmbDay = new ComboBox();
            lblDay = new Label();
            txtAmount = new TextBox();
            lblAmount = new Label();
            txtTitle = new TextBox();
            lblExpenseTitle = new Label();
            panelList = new Panel();
            dgvFixedExpenses = new DataGridView();
            lblListTitle = new Label();
            panelInput.SuspendLayout();
            panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFixedExpenses).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("맑은 고딕", 22F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(32, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(134, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "고정지출";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("맑은 고딕", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(36, 68);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(327, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "매달 반복되는 구독료, 통신비, 보험료를 관리합니다.";
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.White;
            panelInput.BorderStyle = BorderStyle.FixedSingle;
            panelInput.Controls.Add(btnAdd);
            panelInput.Controls.Add(chkIsActive);
            panelInput.Controls.Add(txtMemo);
            panelInput.Controls.Add(lblMemo);
            panelInput.Controls.Add(cmbPayment);
            panelInput.Controls.Add(lblPayment);
            panelInput.Controls.Add(cmbCategory);
            panelInput.Controls.Add(lblCategory);
            panelInput.Controls.Add(cmbDay);
            panelInput.Controls.Add(lblDay);
            panelInput.Controls.Add(txtAmount);
            panelInput.Controls.Add(lblAmount);
            panelInput.Controls.Add(txtTitle);
            panelInput.Controls.Add(lblExpenseTitle);
            panelInput.Location = new Point(32, 104);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(756, 162);
            panelInput.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(37, 99, 235);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(636, 108);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 34);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "등록";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Font = new Font("맑은 고딕", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            chkIsActive.ForeColor = Color.FromArgb(51, 65, 85);
            chkIsActive.Location = new Point(24, 116);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(164, 21);
            chkIsActive.TabIndex = 12;
            chkIsActive.Text = "매달 자동 생성 활성화";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtMemo
            // 
            txtMemo.BorderStyle = BorderStyle.FixedSingle;
            txtMemo.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txtMemo.Location = new Point(444, 48);
            txtMemo.Name = "txtMemo";
            txtMemo.PlaceholderText = "메모";
            txtMemo.Size = new Size(280, 25);
            txtMemo.TabIndex = 11;
            // 
            // lblMemo
            // 
            lblMemo.AutoSize = true;
            lblMemo.Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblMemo.ForeColor = Color.FromArgb(30, 41, 59);
            lblMemo.Location = new Point(444, 26);
            lblMemo.Name = "lblMemo";
            lblMemo.Size = new Size(34, 17);
            lblMemo.TabIndex = 10;
            lblMemo.Text = "메모";
            // 
            // cmbPayment
            // 
            cmbPayment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPayment.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            cmbPayment.FormattingEnabled = true;
            cmbPayment.Items.AddRange(new object[] { "카드", "현금", "계좌이체", "간편결제", "기타" });
            cmbPayment.Location = new Point(332, 48);
            cmbPayment.Name = "cmbPayment";
            cmbPayment.Size = new Size(96, 25);
            cmbPayment.TabIndex = 9;
            // 
            // lblPayment
            // 
            lblPayment.AutoSize = true;
            lblPayment.Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblPayment.ForeColor = Color.FromArgb(30, 41, 59);
            lblPayment.Location = new Point(332, 26);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(60, 17);
            lblPayment.TabIndex = 8;
            lblPayment.Text = "결제수단";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "식비", "주거", "통신", "교통", "문화/생활", "보험", "기타" });
            cmbCategory.Location = new Point(220, 48);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(96, 25);
            cmbCategory.TabIndex = 7;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblCategory.ForeColor = Color.FromArgb(30, 41, 59);
            lblCategory.Location = new Point(220, 26);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(60, 17);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "카테고리";
            // 
            // cmbDay
            // 
            cmbDay.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDay.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            cmbDay.FormattingEnabled = true;
            cmbDay.Location = new Point(140, 48);
            cmbDay.Name = "cmbDay";
            cmbDay.Size = new Size(64, 25);
            cmbDay.TabIndex = 5;
            // 
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblDay.ForeColor = Color.FromArgb(30, 41, 59);
            lblDay.Location = new Point(140, 26);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(47, 17);
            lblDay.TabIndex = 4;
            lblDay.Text = "발생일";
            // 
            // txtAmount
            // 
            txtAmount.BorderStyle = BorderStyle.FixedSingle;
            txtAmount.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txtAmount.Location = new Point(24, 48);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderText = "금액";
            txtAmount.Size = new Size(100, 25);
            txtAmount.TabIndex = 3;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAmount.ForeColor = Color.FromArgb(30, 41, 59);
            lblAmount.Location = new Point(24, 26);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(34, 17);
            lblAmount.TabIndex = 2;
            lblAmount.Text = "금액";
            // 
            // txtTitle
            // 
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txtTitle.Location = new Point(24, 82);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "지출명 예: 넷플릭스, 통신비";
            txtTitle.Size = new Size(404, 25);
            txtTitle.TabIndex = 1;
            // 
            // lblExpenseTitle
            // 
            lblExpenseTitle.AutoSize = true;
            lblExpenseTitle.Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblExpenseTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblExpenseTitle.Location = new Point(24, 84);
            lblExpenseTitle.Name = "lblExpenseTitle";
            lblExpenseTitle.Size = new Size(0, 17);
            lblExpenseTitle.TabIndex = 0;
            // 
            // panelList
            // 
            panelList.BackColor = Color.White;
            panelList.BorderStyle = BorderStyle.FixedSingle;
            panelList.Controls.Add(dgvFixedExpenses);
            panelList.Controls.Add(lblListTitle);
            panelList.Location = new Point(32, 284);
            panelList.Name = "panelList";
            panelList.Size = new Size(756, 230);
            panelList.TabIndex = 3;
            // 
            // dgvFixedExpenses
            // 
            dgvFixedExpenses.AllowUserToAddRows = false;
            dgvFixedExpenses.AllowUserToDeleteRows = false;
            dgvFixedExpenses.AllowUserToResizeRows = false;
            dgvFixedExpenses.BackgroundColor = Color.White;
            dgvFixedExpenses.BorderStyle = BorderStyle.FixedSingle;
            dgvFixedExpenses.ColumnHeadersHeight = 32;
            dgvFixedExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvFixedExpenses.GridColor = Color.FromArgb(226, 232, 240);
            dgvFixedExpenses.Location = new Point(24, 50);
            dgvFixedExpenses.MultiSelect = false;
            dgvFixedExpenses.Name = "dgvFixedExpenses";
            dgvFixedExpenses.ReadOnly = true;
            dgvFixedExpenses.RowHeadersVisible = false;
            dgvFixedExpenses.RowTemplate.Height = 32;
            dgvFixedExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFixedExpenses.Size = new Size(706, 154);
            dgvFixedExpenses.TabIndex = 1;
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblListTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblListTitle.Location = new Point(24, 17);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(138, 21);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "등록된 고정지출";
            // 
            // FormFixedExpense
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(820, 540);
            Controls.Add(panelList);
            Controls.Add(panelInput);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormFixedExpense";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MoneyNote - 고정지출 관리";
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelList.ResumeLayout(false);
            panelList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFixedExpenses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private Panel panelInput;
        private TextBox txtTitle;
        private TextBox txtAmount;
        private ComboBox cmbDay;
        private ComboBox cmbCategory;
        private ComboBox cmbPayment;
        private TextBox txtMemo;
        private CheckBox chkIsActive;
        private Button btnAdd;
        private Label lblExpenseTitle;
        private Label lblAmount;
        private Label lblDay;
        private Label lblCategory;
        private Label lblPayment;
        private Label lblMemo;
        private Panel panelList;
        private DataGridView dgvFixedExpenses;
        private Label lblListTitle;
    }
}
