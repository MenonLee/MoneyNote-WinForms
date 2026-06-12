namespace ScheduleProject
{
    partial class FormBudget
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
            panelMonth = new Panel();
            dateBudgetMonth = new DateTimePicker();
            lblMonth = new Label();
            panelMonthly = new Panel();
            buttonSaveMonthly = new Button();
            textMonthlyBudget = new TextBox();
            lblMonthlyGuide = new Label();
            lblMonthlyTitle = new Label();
            panelCategory = new Panel();
            buttonSaveCategory = new Button();
            textCategoryBudget = new TextBox();
            comboCategory = new ComboBox();
            lblCategoryAmount = new Label();
            lblCategoryName = new Label();
            lblCategoryTitle = new Label();
            panelSummary = new Panel();
            lblRemainSummaryValue = new Label();
            lblRemainSummary = new Label();
            lblCategorySummaryValue = new Label();
            lblCategorySummary = new Label();
            lblExpenseSummaryValue = new Label();
            lblExpenseSummary = new Label();
            lblMonthSummaryValue = new Label();
            lblMonthSummary = new Label();
            panelList = new Panel();
            dgvBudgets = new DataGridView();
            lblListTitle = new Label();
            buttonRefresh = new Button();
            buttonClose = new Button();
            panelMonth.SuspendLayout();
            panelMonthly.SuspendLayout();
            panelCategory.SuspendLayout();
            panelSummary.SuspendLayout();
            panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBudgets).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(32, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(165, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "예산 관리";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(36, 67);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(332, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "월 전체 예산과 카테고리별 예산을 설정합니다.";
            // 
            // panelMonth
            // 
            panelMonth.BackColor = Color.White;
            panelMonth.BorderStyle = BorderStyle.FixedSingle;
            panelMonth.Controls.Add(dateBudgetMonth);
            panelMonth.Controls.Add(lblMonth);
            panelMonth.Location = new Point(476, 34);
            panelMonth.Name = "panelMonth";
            panelMonth.Size = new Size(250, 52);
            panelMonth.TabIndex = 2;
            // 
            // dateBudgetMonth
            // 
            dateBudgetMonth.CustomFormat = "yyyy년 MM월";
            dateBudgetMonth.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            dateBudgetMonth.Format = DateTimePickerFormat.Custom;
            dateBudgetMonth.Location = new Point(86, 13);
            dateBudgetMonth.Name = "dateBudgetMonth";
            dateBudgetMonth.ShowUpDown = true;
            dateBudgetMonth.Size = new Size(150, 25);
            dateBudgetMonth.TabIndex = 1;
            dateBudgetMonth.ValueChanged += dateBudgetMonth_ValueChanged;
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblMonth.ForeColor = Color.FromArgb(30, 41, 59);
            lblMonth.Location = new Point(22, 16);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(51, 19);
            lblMonth.TabIndex = 0;
            lblMonth.Text = "대상 월";
            // 
            // panelMonthly
            // 
            panelMonthly.BackColor = Color.White;
            panelMonthly.BorderStyle = BorderStyle.FixedSingle;
            panelMonthly.Controls.Add(buttonSaveMonthly);
            panelMonthly.Controls.Add(textMonthlyBudget);
            panelMonthly.Controls.Add(lblMonthlyGuide);
            panelMonthly.Controls.Add(lblMonthlyTitle);
            panelMonthly.Location = new Point(32, 105);
            panelMonthly.Name = "panelMonthly";
            panelMonthly.Size = new Size(340, 132);
            panelMonthly.TabIndex = 3;
            // 
            // buttonSaveMonthly
            // 
            buttonSaveMonthly.BackColor = Color.FromArgb(37, 99, 235);
            buttonSaveMonthly.FlatAppearance.BorderSize = 0;
            buttonSaveMonthly.FlatStyle = FlatStyle.Flat;
            buttonSaveMonthly.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            buttonSaveMonthly.ForeColor = Color.White;
            buttonSaveMonthly.Location = new Point(236, 84);
            buttonSaveMonthly.Name = "buttonSaveMonthly";
            buttonSaveMonthly.Size = new Size(94, 34);
            buttonSaveMonthly.TabIndex = 3;
            buttonSaveMonthly.Text = "저장";
            buttonSaveMonthly.UseVisualStyleBackColor = false;
            buttonSaveMonthly.Click += buttonSaveMonthly_Click;
            // 
            // textMonthlyBudget
            // 
            textMonthlyBudget.BorderStyle = BorderStyle.FixedSingle;
            textMonthlyBudget.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textMonthlyBudget.Location = new Point(24, 87);
            textMonthlyBudget.Name = "textMonthlyBudget";
            textMonthlyBudget.PlaceholderText = "예: 500000";
            textMonthlyBudget.Size = new Size(200, 27);
            textMonthlyBudget.TabIndex = 2;
            // 
            // lblMonthlyGuide
            // 
            lblMonthlyGuide.AutoSize = true;
            lblMonthlyGuide.Font = new Font("맑은 고딕", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblMonthlyGuide.ForeColor = Color.FromArgb(100, 116, 139);
            lblMonthlyGuide.Location = new Point(24, 52);
            lblMonthlyGuide.Name = "lblMonthlyGuide";
            lblMonthlyGuide.Size = new Size(259, 17);
            lblMonthlyGuide.TabIndex = 1;
            lblMonthlyGuide.Text = "대시보드의 예산 사용률 계산에 사용됩니다.";
            // 
            // lblMonthlyTitle
            // 
            lblMonthlyTitle.AutoSize = true;
            lblMonthlyTitle.Font = new Font("맑은 고딕", 13F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblMonthlyTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblMonthlyTitle.Location = new Point(24, 20);
            lblMonthlyTitle.Name = "lblMonthlyTitle";
            lblMonthlyTitle.Size = new Size(126, 25);
            lblMonthlyTitle.TabIndex = 0;
            lblMonthlyTitle.Text = "월 전체 예산";
            // 
            // panelCategory
            // 
            panelCategory.BackColor = Color.White;
            panelCategory.BorderStyle = BorderStyle.FixedSingle;
            panelCategory.Controls.Add(buttonSaveCategory);
            panelCategory.Controls.Add(textCategoryBudget);
            panelCategory.Controls.Add(comboCategory);
            panelCategory.Controls.Add(lblCategoryAmount);
            panelCategory.Controls.Add(lblCategoryName);
            panelCategory.Controls.Add(lblCategoryTitle);
            panelCategory.Location = new Point(386, 105);
            panelCategory.Name = "panelCategory";
            panelCategory.Size = new Size(340, 132);
            panelCategory.TabIndex = 4;
            // 
            // buttonSaveCategory
            // 
            buttonSaveCategory.BackColor = Color.FromArgb(37, 99, 235);
            buttonSaveCategory.FlatAppearance.BorderSize = 0;
            buttonSaveCategory.FlatStyle = FlatStyle.Flat;
            buttonSaveCategory.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            buttonSaveCategory.ForeColor = Color.White;
            buttonSaveCategory.Location = new Point(222, 84);
            buttonSaveCategory.Name = "buttonSaveCategory";
            buttonSaveCategory.Size = new Size(94, 34);
            buttonSaveCategory.TabIndex = 5;
            buttonSaveCategory.Text = "저장";
            buttonSaveCategory.UseVisualStyleBackColor = false;
            buttonSaveCategory.Click += buttonSaveCategory_Click;
            // 
            // textCategoryBudget
            // 
            textCategoryBudget.BorderStyle = BorderStyle.FixedSingle;
            textCategoryBudget.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            textCategoryBudget.Location = new Point(126, 89);
            textCategoryBudget.Name = "textCategoryBudget";
            textCategoryBudget.PlaceholderText = "예: 120000";
            textCategoryBudget.Size = new Size(86, 25);
            textCategoryBudget.TabIndex = 4;
            // 
            // comboCategory
            // 
            comboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategory.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            comboCategory.FormattingEnabled = true;
            comboCategory.Location = new Point(24, 89);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(97, 25);
            comboCategory.TabIndex = 3;
            // 
            // lblCategoryAmount
            // 
            lblCategoryAmount.AutoSize = true;
            lblCategoryAmount.Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblCategoryAmount.ForeColor = Color.FromArgb(30, 41, 59);
            lblCategoryAmount.Location = new Point(126, 68);
            lblCategoryAmount.Name = "lblCategoryAmount";
            lblCategoryAmount.Size = new Size(34, 17);
            lblCategoryAmount.TabIndex = 2;
            lblCategoryAmount.Text = "금액";
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblCategoryName.ForeColor = Color.FromArgb(30, 41, 59);
            lblCategoryName.Location = new Point(24, 68);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(60, 17);
            lblCategoryName.TabIndex = 1;
            lblCategoryName.Text = "카테고리";
            // 
            // lblCategoryTitle
            // 
            lblCategoryTitle.AutoSize = true;
            lblCategoryTitle.Font = new Font("맑은 고딕", 13F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblCategoryTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblCategoryTitle.Location = new Point(24, 20);
            lblCategoryTitle.Name = "lblCategoryTitle";
            lblCategoryTitle.Size = new Size(155, 25);
            lblCategoryTitle.TabIndex = 0;
            lblCategoryTitle.Text = "카테고리별 예산";
            // 
            // panelSummary
            // 
            panelSummary.BackColor = Color.White;
            panelSummary.BorderStyle = BorderStyle.FixedSingle;
            panelSummary.Controls.Add(lblRemainSummaryValue);
            panelSummary.Controls.Add(lblRemainSummary);
            panelSummary.Controls.Add(lblCategorySummaryValue);
            panelSummary.Controls.Add(lblCategorySummary);
            panelSummary.Controls.Add(lblExpenseSummaryValue);
            panelSummary.Controls.Add(lblExpenseSummary);
            panelSummary.Controls.Add(lblMonthSummaryValue);
            panelSummary.Controls.Add(lblMonthSummary);
            panelSummary.Location = new Point(32, 258);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(694, 82);
            panelSummary.TabIndex = 5;
            // 
            // lblRemainSummaryValue
            // 
            lblRemainSummaryValue.AutoSize = true;
            lblRemainSummaryValue.Font = new Font("맑은 고딕", 13F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblRemainSummaryValue.ForeColor = Color.FromArgb(15, 118, 110);
            lblRemainSummaryValue.Location = new Point(532, 39);
            lblRemainSummaryValue.Name = "lblRemainSummaryValue";
            lblRemainSummaryValue.Size = new Size(22, 25);
            lblRemainSummaryValue.TabIndex = 7;
            lblRemainSummaryValue.Text = "0";
            // 
            // lblRemainSummary
            // 
            lblRemainSummary.AutoSize = true;
            lblRemainSummary.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblRemainSummary.ForeColor = Color.FromArgb(100, 116, 139);
            lblRemainSummary.Location = new Point(532, 19);
            lblRemainSummary.Name = "lblRemainSummary";
            lblRemainSummary.Size = new Size(59, 15);
            lblRemainSummary.TabIndex = 6;
            lblRemainSummary.Text = "남은 예산";
            // 
            // lblCategorySummaryValue
            // 
            lblCategorySummaryValue.AutoSize = true;
            lblCategorySummaryValue.Font = new Font("맑은 고딕", 13F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblCategorySummaryValue.ForeColor = Color.FromArgb(194, 65, 12);
            lblCategorySummaryValue.Location = new Point(360, 39);
            lblCategorySummaryValue.Name = "lblCategorySummaryValue";
            lblCategorySummaryValue.Size = new Size(22, 25);
            lblCategorySummaryValue.TabIndex = 5;
            lblCategorySummaryValue.Text = "0";
            // 
            // lblCategorySummary
            // 
            lblCategorySummary.AutoSize = true;
            lblCategorySummary.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblCategorySummary.ForeColor = Color.FromArgb(100, 116, 139);
            lblCategorySummary.Location = new Point(360, 19);
            lblCategorySummary.Name = "lblCategorySummary";
            lblCategorySummary.Size = new Size(101, 15);
            lblCategorySummary.TabIndex = 4;
            lblCategorySummary.Text = "카테고리 예산 합";
            // 
            // lblExpenseSummaryValue
            // 
            lblExpenseSummaryValue.AutoSize = true;
            lblExpenseSummaryValue.Font = new Font("맑은 고딕", 13F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblExpenseSummaryValue.ForeColor = Color.FromArgb(37, 99, 235);
            lblExpenseSummaryValue.Location = new Point(190, 39);
            lblExpenseSummaryValue.Name = "lblExpenseSummaryValue";
            lblExpenseSummaryValue.Size = new Size(22, 25);
            lblExpenseSummaryValue.TabIndex = 3;
            lblExpenseSummaryValue.Text = "0";
            // 
            // lblExpenseSummary
            // 
            lblExpenseSummary.AutoSize = true;
            lblExpenseSummary.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblExpenseSummary.ForeColor = Color.FromArgb(100, 116, 139);
            lblExpenseSummary.Location = new Point(190, 19);
            lblExpenseSummary.Name = "lblExpenseSummary";
            lblExpenseSummary.Size = new Size(75, 15);
            lblExpenseSummary.TabIndex = 2;
            lblExpenseSummary.Text = "이번 달 지출";
            // 
            // lblMonthSummaryValue
            // 
            lblMonthSummaryValue.AutoSize = true;
            lblMonthSummaryValue.Font = new Font("맑은 고딕", 13F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblMonthSummaryValue.ForeColor = Color.FromArgb(15, 23, 42);
            lblMonthSummaryValue.Location = new Point(28, 39);
            lblMonthSummaryValue.Name = "lblMonthSummaryValue";
            lblMonthSummaryValue.Size = new Size(22, 25);
            lblMonthSummaryValue.TabIndex = 1;
            lblMonthSummaryValue.Text = "0";
            // 
            // lblMonthSummary
            // 
            lblMonthSummary.AutoSize = true;
            lblMonthSummary.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblMonthSummary.ForeColor = Color.FromArgb(100, 116, 139);
            lblMonthSummary.Location = new Point(28, 19);
            lblMonthSummary.Name = "lblMonthSummary";
            lblMonthSummary.Size = new Size(75, 15);
            lblMonthSummary.TabIndex = 0;
            lblMonthSummary.Text = "월 전체 예산";
            // 
            // panelList
            // 
            panelList.BackColor = Color.White;
            panelList.BorderStyle = BorderStyle.FixedSingle;
            panelList.Controls.Add(dgvBudgets);
            panelList.Controls.Add(lblListTitle);
            panelList.Location = new Point(32, 360);
            panelList.Name = "panelList";
            panelList.Size = new Size(694, 196);
            panelList.TabIndex = 6;
            // 
            // dgvBudgets
            // 
            dgvBudgets.AllowUserToAddRows = false;
            dgvBudgets.AllowUserToDeleteRows = false;
            dgvBudgets.AllowUserToResizeRows = false;
            dgvBudgets.BackgroundColor = Color.White;
            dgvBudgets.BorderStyle = BorderStyle.None;
            dgvBudgets.ColumnHeadersHeight = 32;
            dgvBudgets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBudgets.GridColor = Color.FromArgb(226, 232, 240);
            dgvBudgets.Location = new Point(24, 50);
            dgvBudgets.MultiSelect = false;
            dgvBudgets.Name = "dgvBudgets";
            dgvBudgets.ReadOnly = true;
            dgvBudgets.RowHeadersVisible = false;
            dgvBudgets.RowTemplate.Height = 34;
            dgvBudgets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBudgets.Size = new Size(646, 124);
            dgvBudgets.TabIndex = 1;
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblListTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblListTitle.Location = new Point(24, 17);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(141, 21);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "현재 설정된 예산";
            // 
            // buttonRefresh
            // 
            buttonRefresh.BackColor = Color.FromArgb(37, 99, 235);
            buttonRefresh.FlatAppearance.BorderSize = 0;
            buttonRefresh.FlatStyle = FlatStyle.Flat;
            buttonRefresh.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point, 129);
            buttonRefresh.ForeColor = Color.White;
            buttonRefresh.Location = new Point(502, 575);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(126, 40);
            buttonRefresh.TabIndex = 7;
            buttonRefresh.Text = "새로고침";
            buttonRefresh.UseVisualStyleBackColor = false;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.White;
            buttonClose.FlatAppearance.BorderColor = Color.FromArgb(148, 163, 184);
            buttonClose.FlatAppearance.BorderSize = 2;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point, 129);
            buttonClose.ForeColor = Color.FromArgb(51, 65, 85);
            buttonClose.Location = new Point(631, 575);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(95, 40);
            buttonClose.TabIndex = 8;
            buttonClose.Text = "닫기";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // FormBudget
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(760, 635);
            Controls.Add(buttonClose);
            Controls.Add(buttonRefresh);
            Controls.Add(panelList);
            Controls.Add(panelSummary);
            Controls.Add(panelCategory);
            Controls.Add(panelMonthly);
            Controls.Add(panelMonth);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormBudget";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MoneyNote - 예산 관리";
            panelMonth.ResumeLayout(false);
            panelMonth.PerformLayout();
            panelMonthly.ResumeLayout(false);
            panelMonthly.PerformLayout();
            panelCategory.ResumeLayout(false);
            panelCategory.PerformLayout();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            panelList.ResumeLayout(false);
            panelList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBudgets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblSubtitle;
        private Panel panelMonth;
        private DateTimePicker dateBudgetMonth;
        private Label lblMonth;
        private Panel panelMonthly;
        private Button buttonSaveMonthly;
        private TextBox textMonthlyBudget;
        private Label lblMonthlyGuide;
        private Label lblMonthlyTitle;
        private Panel panelCategory;
        private Button buttonSaveCategory;
        private TextBox textCategoryBudget;
        private ComboBox comboCategory;
        private Label lblCategoryAmount;
        private Label lblCategoryName;
        private Label lblCategoryTitle;
        private Panel panelSummary;
        private Label lblRemainSummaryValue;
        private Label lblRemainSummary;
        private Label lblCategorySummaryValue;
        private Label lblCategorySummary;
        private Label lblExpenseSummaryValue;
        private Label lblExpenseSummary;
        private Label lblMonthSummaryValue;
        private Label lblMonthSummary;
        private Panel panelList;
        private DataGridView dgvBudgets;
        private Label lblListTitle;
        private Button buttonRefresh;
        private Button buttonClose;
    }
}
