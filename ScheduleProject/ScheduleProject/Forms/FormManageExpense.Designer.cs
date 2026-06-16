namespace ScheduleProject
{
    partial class FormManageExpense
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

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubtitle = new Label();
            panelList = new Panel();
            buttonRefresh = new Button();
            dgvExpenses = new DataGridView();
            lblListTitle = new Label();
            panelEdit = new Panel();
            buttonDelete = new Button();
            buttonUpdate = new Button();
            checkIsFixed = new CheckBox();
            textMemo = new TextBox();
            lblMemo = new Label();
            dateExpense = new DateTimePicker();
            lblExpenseDate = new Label();
            comboPaymentMethod = new ComboBox();
            lblPaymentMethod = new Label();
            comboCategory = new ComboBox();
            lblCategory = new Label();
            textAmount = new TextBox();
            lblAmount = new Label();
            textTitle = new TextBox();
            lblExpenseTitle = new Label();
            lblEditHeader = new Label();
            buttonClose = new Button();
            panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            panelEdit.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(40, 35);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(237, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "지출 관리";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(44, 93);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(545, 28);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "목록에서 지출을 선택한 뒤 수정하거나 삭제할 수 있습니다.";
            // 
            // panelList
            // 
            panelList.BackColor = Color.White;
            panelList.BorderStyle = BorderStyle.FixedSingle;
            panelList.Controls.Add(buttonRefresh);
            panelList.Controls.Add(dgvExpenses);
            panelList.Controls.Add(lblListTitle);
            panelList.Location = new Point(35, 128);
            panelList.Name = "panelList";
            panelList.Size = new Size(490, 560);
            panelList.TabIndex = 2;
            // 
            // buttonRefresh
            // 
            buttonRefresh.BackColor = Color.White;
            buttonRefresh.FlatAppearance.BorderColor = Color.FromArgb(148, 163, 184);
            buttonRefresh.FlatStyle = FlatStyle.Flat;
            buttonRefresh.Font = new Font("맑은 고딕", 8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonRefresh.ForeColor = Color.FromArgb(51, 65, 85);
            buttonRefresh.Location = new Point(20, 524);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(450, 28);
            buttonRefresh.TabIndex = 2;
            buttonRefresh.Text = "새로고침";
            buttonRefresh.UseVisualStyleBackColor = false;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // dgvExpenses
            // 
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.AllowUserToDeleteRows = false;
            dgvExpenses.AllowUserToResizeRows = false;
            dgvExpenses.BackgroundColor = Color.White;
            dgvExpenses.BorderStyle = BorderStyle.None;
            dgvExpenses.ColumnHeadersHeight = 32;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvExpenses.GridColor = Color.FromArgb(226, 232, 240);
            dgvExpenses.Location = new Point(20, 50);
            dgvExpenses.MultiSelect = false;
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.ReadOnly = true;
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.RowHeadersWidth = 62;
            dgvExpenses.RowTemplate.Height = 30;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.Size = new Size(450, 465);
            dgvExpenses.TabIndex = 1;
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblListTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblListTitle.Location = new Point(20, 16);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(118, 32);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "지출 목록";
            // 
            // panelEdit
            // 
            panelEdit.BackColor = Color.White;
            panelEdit.BorderStyle = BorderStyle.FixedSingle;
            panelEdit.Controls.Add(buttonDelete);
            panelEdit.Controls.Add(buttonUpdate);
            panelEdit.Controls.Add(checkIsFixed);
            panelEdit.Controls.Add(textMemo);
            panelEdit.Controls.Add(lblMemo);
            panelEdit.Controls.Add(dateExpense);
            panelEdit.Controls.Add(lblExpenseDate);
            panelEdit.Controls.Add(comboPaymentMethod);
            panelEdit.Controls.Add(lblPaymentMethod);
            panelEdit.Controls.Add(comboCategory);
            panelEdit.Controls.Add(lblCategory);
            panelEdit.Controls.Add(textAmount);
            panelEdit.Controls.Add(lblAmount);
            panelEdit.Controls.Add(textTitle);
            panelEdit.Controls.Add(lblExpenseTitle);
            panelEdit.Controls.Add(lblEditHeader);
            panelEdit.Location = new Point(560, 128);
            panelEdit.Name = "panelEdit";
            panelEdit.Size = new Size(540, 560);
            panelEdit.TabIndex = 3;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(220, 38, 38);
            buttonDelete.Enabled = false;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point, 129);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(265, 475);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(215, 55);
            buttonDelete.TabIndex = 15;
            buttonDelete.Text = "삭제";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = Color.FromArgb(37, 99, 235);
            buttonUpdate.Enabled = false;
            buttonUpdate.FlatAppearance.BorderSize = 0;
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point, 129);
            buttonUpdate.ForeColor = Color.White;
            buttonUpdate.Location = new Point(30, 475);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(215, 55);
            buttonUpdate.TabIndex = 14;
            buttonUpdate.Text = "수정";
            buttonUpdate.UseVisualStyleBackColor = false;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // checkIsFixed
            // 
            checkIsFixed.AutoSize = true;
            checkIsFixed.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            checkIsFixed.ForeColor = Color.FromArgb(51, 65, 85);
            checkIsFixed.Location = new Point(30, 422);
            checkIsFixed.Name = "checkIsFixed";
            checkIsFixed.Size = new Size(259, 32);
            checkIsFixed.TabIndex = 13;
            checkIsFixed.Text = "매달 반복되는 고정 지출";
            checkIsFixed.UseVisualStyleBackColor = true;
            // 
            // textMemo
            // 
            textMemo.BorderStyle = BorderStyle.FixedSingle;
            textMemo.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textMemo.Location = new Point(30, 328);
            textMemo.Multiline = true;
            textMemo.Name = "textMemo";
            textMemo.Size = new Size(480, 80);
            textMemo.TabIndex = 12;
            // 
            // lblMemo
            // 
            lblMemo.AutoSize = true;
            lblMemo.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblMemo.ForeColor = Color.FromArgb(30, 41, 59);
            lblMemo.Location = new Point(30, 300);
            lblMemo.Name = "lblMemo";
            lblMemo.Size = new Size(52, 28);
            lblMemo.TabIndex = 11;
            lblMemo.Text = "메모";
            // 
            // dateExpense
            // 
            dateExpense.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            dateExpense.Format = DateTimePickerFormat.Short;
            dateExpense.Location = new Point(285, 246);
            dateExpense.Name = "dateExpense";
            dateExpense.Size = new Size(225, 34);
            dateExpense.TabIndex = 10;
            // 
            // lblExpenseDate
            // 
            lblExpenseDate.AutoSize = true;
            lblExpenseDate.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblExpenseDate.ForeColor = Color.FromArgb(30, 41, 59);
            lblExpenseDate.Location = new Point(285, 218);
            lblExpenseDate.Name = "lblExpenseDate";
            lblExpenseDate.Size = new Size(99, 28);
            lblExpenseDate.TabIndex = 9;
            lblExpenseDate.Text = "지출 날짜";
            // 
            // comboPaymentMethod
            // 
            comboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPaymentMethod.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            comboPaymentMethod.FormattingEnabled = true;
            comboPaymentMethod.Items.AddRange(new object[] { "카드", "현금", "계좌이체", "간편결제", "기타" });
            comboPaymentMethod.Location = new Point(30, 246);
            comboPaymentMethod.Name = "comboPaymentMethod";
            comboPaymentMethod.Size = new Size(225, 36);
            comboPaymentMethod.TabIndex = 8;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblPaymentMethod.ForeColor = Color.FromArgb(30, 41, 59);
            lblPaymentMethod.Location = new Point(30, 218);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(92, 28);
            lblPaymentMethod.TabIndex = 7;
            lblPaymentMethod.Text = "결제수단";
            // 
            // comboCategory
            // 
            comboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategory.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            comboCategory.FormattingEnabled = true;
            comboCategory.Items.AddRange(new object[] { "식비", "교통", "쇼핑", "문화", "생활", "통신", "기타" });
            comboCategory.Location = new Point(285, 164);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(225, 36);
            comboCategory.TabIndex = 6;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblCategory.ForeColor = Color.FromArgb(30, 41, 59);
            lblCategory.Location = new Point(285, 136);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(92, 28);
            lblCategory.TabIndex = 5;
            lblCategory.Text = "카테고리";
            // 
            // textAmount
            // 
            textAmount.BorderStyle = BorderStyle.FixedSingle;
            textAmount.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textAmount.Location = new Point(30, 164);
            textAmount.Name = "textAmount";
            textAmount.Size = new Size(225, 34);
            textAmount.TabIndex = 4;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAmount.ForeColor = Color.FromArgb(30, 41, 59);
            lblAmount.Location = new Point(30, 136);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(52, 28);
            lblAmount.TabIndex = 3;
            lblAmount.Text = "금액";
            // 
            // textTitle
            // 
            textTitle.BorderStyle = BorderStyle.FixedSingle;
            textTitle.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textTitle.Location = new Point(30, 84);
            textTitle.Name = "textTitle";
            textTitle.Size = new Size(480, 34);
            textTitle.TabIndex = 2;
            // 
            // lblExpenseTitle
            // 
            lblExpenseTitle.AutoSize = true;
            lblExpenseTitle.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblExpenseTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblExpenseTitle.Location = new Point(30, 56);
            lblExpenseTitle.Name = "lblExpenseTitle";
            lblExpenseTitle.Size = new Size(72, 28);
            lblExpenseTitle.TabIndex = 1;
            lblExpenseTitle.Text = "지출명";
            // 
            // lblEditHeader
            // 
            lblEditHeader.AutoSize = true;
            lblEditHeader.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblEditHeader.ForeColor = Color.FromArgb(30, 41, 59);
            lblEditHeader.Location = new Point(30, 18);
            lblEditHeader.Name = "lblEditHeader";
            lblEditHeader.Size = new Size(198, 32);
            lblEditHeader.TabIndex = 0;
            lblEditHeader.Text = "선택한 항목 수정";
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.White;
            buttonClose.FlatAppearance.BorderColor = Color.FromArgb(148, 163, 184);
            buttonClose.FlatAppearance.BorderSize = 2;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point, 129);
            buttonClose.ForeColor = Color.FromArgb(51, 65, 85);
            buttonClose.Location = new Point(980, 702);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(120, 42);
            buttonClose.TabIndex = 4;
            buttonClose.Text = "닫기";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // FormManageExpense
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1140, 755);
            Controls.Add(buttonClose);
            Controls.Add(panelEdit);
            Controls.Add(panelList);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormManageExpense";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MoneyNote - 지출 관리";
            panelList.ResumeLayout(false);
            panelList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            panelEdit.ResumeLayout(false);
            panelEdit.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblSubtitle;
        private Panel panelList;
        private Label lblListTitle;
        private DataGridView dgvExpenses;
        private Button buttonRefresh;
        private Panel panelEdit;
        private Label lblEditHeader;
        private Label lblExpenseTitle;
        private TextBox textTitle;
        private Label lblAmount;
        private TextBox textAmount;
        private Label lblCategory;
        private ComboBox comboCategory;
        private Label lblPaymentMethod;
        private ComboBox comboPaymentMethod;
        private Label lblExpenseDate;
        private DateTimePicker dateExpense;
        private Label lblMemo;
        private TextBox textMemo;
        private CheckBox checkIsFixed;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonClose;
    }
}
