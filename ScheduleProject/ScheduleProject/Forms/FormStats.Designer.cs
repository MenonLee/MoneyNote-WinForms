namespace ScheduleProject
{
    partial class FormStats
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
            panelTotalCount = new Panel();
            lblTotalCountCaption = new Label();
            lblTotalCountValue = new Label();
            panelTotalAmount = new Panel();
            lblTotalAmountCaption = new Label();
            lblTotalAmountValue = new Label();
            panelMonthlyAmount = new Panel();
            lblMonthlyAmountCaption = new Label();
            lblMonthlyAmountValue = new Label();
            panelAverageAmount = new Panel();
            lblAverageAmountCaption = new Label();
            lblAverageAmountValue = new Label();
            panelCategory = new Panel();
            lblCategoryTitle = new Label();
            dgvCategory = new DataGridView();
            buttonRefresh = new Button();
            buttonClose = new Button();
            panelTotalCount.SuspendLayout();
            panelTotalAmount.SuspendLayout();
            panelMonthlyAmount.SuspendLayout();
            panelAverageAmount.SuspendLayout();
            panelCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
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
            lblTitle.Text = "지출 통계";
            //
            // lblSubtitle
            //
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(44, 93);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 28);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "전체 기간과 이번 달의 소비 현황을 확인합니다.";
            //
            // panelTotalCount
            //
            panelTotalCount.BackColor = Color.FromArgb(248, 250, 252);
            panelTotalCount.BorderStyle = BorderStyle.FixedSingle;
            panelTotalCount.Controls.Add(lblTotalCountValue);
            panelTotalCount.Controls.Add(lblTotalCountCaption);
            panelTotalCount.Location = new Point(48, 128);
            panelTotalCount.Name = "panelTotalCount";
            panelTotalCount.Size = new Size(200, 104);
            panelTotalCount.TabIndex = 2;
            //
            // lblTotalCountCaption
            //
            lblTotalCountCaption.AutoSize = true;
            lblTotalCountCaption.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblTotalCountCaption.ForeColor = Color.FromArgb(71, 85, 105);
            lblTotalCountCaption.Location = new Point(16, 16);
            lblTotalCountCaption.Name = "lblTotalCountCaption";
            lblTotalCountCaption.Size = new Size(100, 15);
            lblTotalCountCaption.TabIndex = 0;
            lblTotalCountCaption.Text = "전체 지출 건수";
            //
            // lblTotalCountValue
            //
            lblTotalCountValue.AutoSize = true;
            lblTotalCountValue.Font = new Font("맑은 고딕", 15F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTotalCountValue.ForeColor = Color.FromArgb(15, 23, 42);
            lblTotalCountValue.Location = new Point(14, 42);
            lblTotalCountValue.Name = "lblTotalCountValue";
            lblTotalCountValue.Size = new Size(60, 28);
            lblTotalCountValue.TabIndex = 1;
            lblTotalCountValue.Text = "0건";
            //
            // panelTotalAmount
            //
            panelTotalAmount.BackColor = Color.FromArgb(239, 246, 255);
            panelTotalAmount.BorderStyle = BorderStyle.FixedSingle;
            panelTotalAmount.Controls.Add(lblTotalAmountValue);
            panelTotalAmount.Controls.Add(lblTotalAmountCaption);
            panelTotalAmount.Location = new Point(265, 128);
            panelTotalAmount.Name = "panelTotalAmount";
            panelTotalAmount.Size = new Size(200, 104);
            panelTotalAmount.TabIndex = 3;
            //
            // lblTotalAmountCaption
            //
            lblTotalAmountCaption.AutoSize = true;
            lblTotalAmountCaption.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblTotalAmountCaption.ForeColor = Color.FromArgb(30, 64, 175);
            lblTotalAmountCaption.Location = new Point(16, 16);
            lblTotalAmountCaption.Name = "lblTotalAmountCaption";
            lblTotalAmountCaption.Size = new Size(85, 15);
            lblTotalAmountCaption.TabIndex = 0;
            lblTotalAmountCaption.Text = "총 지출 금액";
            //
            // lblTotalAmountValue
            //
            lblTotalAmountValue.AutoSize = true;
            lblTotalAmountValue.Font = new Font("맑은 고딕", 15F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTotalAmountValue.ForeColor = Color.FromArgb(29, 78, 216);
            lblTotalAmountValue.Location = new Point(14, 42);
            lblTotalAmountValue.Name = "lblTotalAmountValue";
            lblTotalAmountValue.Size = new Size(60, 28);
            lblTotalAmountValue.TabIndex = 1;
            lblTotalAmountValue.Text = "0원";
            //
            // panelMonthlyAmount
            //
            panelMonthlyAmount.BackColor = Color.FromArgb(240, 253, 250);
            panelMonthlyAmount.BorderStyle = BorderStyle.FixedSingle;
            panelMonthlyAmount.Controls.Add(lblMonthlyAmountValue);
            panelMonthlyAmount.Controls.Add(lblMonthlyAmountCaption);
            panelMonthlyAmount.Location = new Point(482, 128);
            panelMonthlyAmount.Name = "panelMonthlyAmount";
            panelMonthlyAmount.Size = new Size(200, 104);
            panelMonthlyAmount.TabIndex = 4;
            //
            // lblMonthlyAmountCaption
            //
            lblMonthlyAmountCaption.AutoSize = true;
            lblMonthlyAmountCaption.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblMonthlyAmountCaption.ForeColor = Color.FromArgb(22, 101, 52);
            lblMonthlyAmountCaption.Location = new Point(16, 16);
            lblMonthlyAmountCaption.Name = "lblMonthlyAmountCaption";
            lblMonthlyAmountCaption.Size = new Size(85, 15);
            lblMonthlyAmountCaption.TabIndex = 0;
            lblMonthlyAmountCaption.Text = "이번 달 지출";
            //
            // lblMonthlyAmountValue
            //
            lblMonthlyAmountValue.AutoSize = true;
            lblMonthlyAmountValue.Font = new Font("맑은 고딕", 15F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblMonthlyAmountValue.ForeColor = Color.FromArgb(15, 118, 110);
            lblMonthlyAmountValue.Location = new Point(14, 42);
            lblMonthlyAmountValue.Name = "lblMonthlyAmountValue";
            lblMonthlyAmountValue.Size = new Size(60, 28);
            lblMonthlyAmountValue.TabIndex = 1;
            lblMonthlyAmountValue.Text = "0원";
            //
            // panelAverageAmount
            //
            panelAverageAmount.BackColor = Color.FromArgb(255, 247, 237);
            panelAverageAmount.BorderStyle = BorderStyle.FixedSingle;
            panelAverageAmount.Controls.Add(lblAverageAmountValue);
            panelAverageAmount.Controls.Add(lblAverageAmountCaption);
            panelAverageAmount.Location = new Point(699, 128);
            panelAverageAmount.Name = "panelAverageAmount";
            panelAverageAmount.Size = new Size(200, 104);
            panelAverageAmount.TabIndex = 5;
            //
            // lblAverageAmountCaption
            //
            lblAverageAmountCaption.AutoSize = true;
            lblAverageAmountCaption.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblAverageAmountCaption.ForeColor = Color.FromArgb(154, 52, 18);
            lblAverageAmountCaption.Location = new Point(16, 16);
            lblAverageAmountCaption.Name = "lblAverageAmountCaption";
            lblAverageAmountCaption.Size = new Size(70, 15);
            lblAverageAmountCaption.TabIndex = 0;
            lblAverageAmountCaption.Text = "평균 지출";
            //
            // lblAverageAmountValue
            //
            lblAverageAmountValue.AutoSize = true;
            lblAverageAmountValue.Font = new Font("맑은 고딕", 15F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAverageAmountValue.ForeColor = Color.FromArgb(194, 65, 12);
            lblAverageAmountValue.Location = new Point(14, 42);
            lblAverageAmountValue.Name = "lblAverageAmountValue";
            lblAverageAmountValue.Size = new Size(60, 28);
            lblAverageAmountValue.TabIndex = 1;
            lblAverageAmountValue.Text = "0원";
            //
            // panelCategory
            //
            panelCategory.BackColor = Color.White;
            panelCategory.BorderStyle = BorderStyle.FixedSingle;
            panelCategory.Controls.Add(dgvCategory);
            panelCategory.Controls.Add(lblCategoryTitle);
            panelCategory.Location = new Point(48, 252);
            panelCategory.Name = "panelCategory";
            panelCategory.Size = new Size(854, 375);
            panelCategory.TabIndex = 6;
            //
            // lblCategoryTitle
            //
            lblCategoryTitle.AutoSize = true;
            lblCategoryTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblCategoryTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblCategoryTitle.Location = new Point(20, 16);
            lblCategoryTitle.Name = "lblCategoryTitle";
            lblCategoryTitle.Size = new Size(140, 22);
            lblCategoryTitle.TabIndex = 0;
            lblCategoryTitle.Text = "카테고리별 지출";
            //
            // dgvCategory
            //
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.AllowUserToDeleteRows = false;
            dgvCategory.AllowUserToResizeRows = false;
            dgvCategory.BackgroundColor = Color.White;
            dgvCategory.BorderStyle = BorderStyle.None;
            dgvCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCategory.ColumnHeadersHeight = 32;
            dgvCategory.GridColor = Color.FromArgb(226, 232, 240);
            dgvCategory.Location = new Point(20, 52);
            dgvCategory.MultiSelect = false;
            dgvCategory.Name = "dgvCategory";
            dgvCategory.ReadOnly = true;
            dgvCategory.RowHeadersVisible = false;
            dgvCategory.RowTemplate.Height = 35;
            dgvCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategory.Size = new Size(814, 300);
            dgvCategory.TabIndex = 1;
            //
            // buttonRefresh
            //
            buttonRefresh.BackColor = Color.FromArgb(37, 99, 235);
            buttonRefresh.FlatAppearance.BorderSize = 0;
            buttonRefresh.FlatStyle = FlatStyle.Flat;
            buttonRefresh.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point, 129);
            buttonRefresh.ForeColor = Color.White;
            buttonRefresh.Location = new Point(622, 642);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(160, 45);
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
            buttonClose.Location = new Point(802, 642);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(100, 45);
            buttonClose.TabIndex = 8;
            buttonClose.Text = "닫기";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            //
            // FormStats
            //
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(950, 705);
            Controls.Add(buttonClose);
            Controls.Add(buttonRefresh);
            Controls.Add(panelCategory);
            Controls.Add(panelAverageAmount);
            Controls.Add(panelMonthlyAmount);
            Controls.Add(panelTotalAmount);
            Controls.Add(panelTotalCount);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormStats";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MoneyNote - 지출 통계";
            panelTotalCount.ResumeLayout(false);
            panelTotalCount.PerformLayout();
            panelTotalAmount.ResumeLayout(false);
            panelTotalAmount.PerformLayout();
            panelMonthlyAmount.ResumeLayout(false);
            panelMonthlyAmount.PerformLayout();
            panelAverageAmount.ResumeLayout(false);
            panelAverageAmount.PerformLayout();
            panelCategory.ResumeLayout(false);
            panelCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblSubtitle;
        private Panel panelTotalCount;
        private Label lblTotalCountCaption;
        private Label lblTotalCountValue;
        private Panel panelTotalAmount;
        private Label lblTotalAmountCaption;
        private Label lblTotalAmountValue;
        private Panel panelMonthlyAmount;
        private Label lblMonthlyAmountCaption;
        private Label lblMonthlyAmountValue;
        private Panel panelAverageAmount;
        private Label lblAverageAmountCaption;
        private Label lblAverageAmountValue;
        private Panel panelCategory;
        private Label lblCategoryTitle;
        private DataGridView dgvCategory;
        private Button buttonRefresh;
        private Button buttonClose;
    }
}
