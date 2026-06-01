namespace ScheduleProject
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblToday = new Label();
            lblSubtitle = new Label();
            lblStatus = new Label();
            buttonAddExpense = new Button();
            buttonExpenseList = new Button();
            buttonManageExpense = new Button();
            buttonStats = new Button();
            buttonExit = new Button();
            lblAddExpenseTitle = new Label();
            lblAddExpenseDesc = new Label();
            lblExpenseListTitle = new Label();
            lblExpenseListDesc = new Label();
            lblManageExpenseTitle = new Label();
            lblManageExpenseDesc = new Label();
            lblStatsTitle = new Label();
            lblStatsDesc = new Label();
            lblExitTitle = new Label();
            lblExitDesc = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(58, 42);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(199, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MoneyNote";
            // 
            // lblToday
            // 
            lblToday.BackColor = Color.White;
            lblToday.BorderStyle = BorderStyle.FixedSingle;
            lblToday.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblToday.ForeColor = Color.FromArgb(51, 65, 85);
            lblToday.Location = new Point(594, 54);
            lblToday.Name = "lblToday";
            lblToday.Size = new Size(230, 34);
            lblToday.TabIndex = 2;
            lblToday.Text = "오늘 날짜: 0000-00-00";
            lblToday.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(62, 96);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(370, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "개인 지출을 기록하고 소비 흐름을 확인하는 가계부입니다.";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
            lblStatus.Location = new Point(62, 506);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(241, 15);
            lblStatus.TabIndex = 18;
            lblStatus.Text = "expense.db 초기화 후 각 기능 화면으로 이동합니다.";
            // 
            // buttonAddExpense
            // 
            buttonAddExpense.BackColor = Color.White;
            buttonAddExpense.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
            buttonAddExpense.FlatAppearance.BorderSize = 2;
            buttonAddExpense.FlatStyle = FlatStyle.Flat;
            buttonAddExpense.Location = new Point(62, 150);
            buttonAddExpense.Name = "buttonAddExpense";
            buttonAddExpense.Size = new Size(365, 82);
            buttonAddExpense.TabIndex = 3;
            buttonAddExpense.UseVisualStyleBackColor = false;
            buttonAddExpense.Click += buttonAddExpense_Click;
            // 
            // buttonExpenseList
            // 
            buttonExpenseList.BackColor = Color.White;
            buttonExpenseList.FlatAppearance.BorderColor = Color.FromArgb(5, 150, 105);
            buttonExpenseList.FlatAppearance.BorderSize = 2;
            buttonExpenseList.FlatStyle = FlatStyle.Flat;
            buttonExpenseList.Location = new Point(459, 150);
            buttonExpenseList.Name = "buttonExpenseList";
            buttonExpenseList.Size = new Size(365, 82);
            buttonExpenseList.TabIndex = 4;
            buttonExpenseList.UseVisualStyleBackColor = false;
            buttonExpenseList.Click += buttonExpenseList_Click;
            // 
            // buttonManageExpense
            // 
            buttonManageExpense.BackColor = Color.White;
            buttonManageExpense.FlatAppearance.BorderColor = Color.FromArgb(234, 88, 12);
            buttonManageExpense.FlatAppearance.BorderSize = 2;
            buttonManageExpense.FlatStyle = FlatStyle.Flat;
            buttonManageExpense.Location = new Point(62, 260);
            buttonManageExpense.Name = "buttonManageExpense";
            buttonManageExpense.Size = new Size(365, 82);
            buttonManageExpense.TabIndex = 5;
            buttonManageExpense.UseVisualStyleBackColor = false;
            buttonManageExpense.Click += buttonManageExpense_Click;
            // 
            // buttonStats
            // 
            buttonStats.BackColor = Color.White;
            buttonStats.FlatAppearance.BorderColor = Color.FromArgb(124, 58, 237);
            buttonStats.FlatAppearance.BorderSize = 2;
            buttonStats.FlatStyle = FlatStyle.Flat;
            buttonStats.Location = new Point(459, 260);
            buttonStats.Name = "buttonStats";
            buttonStats.Size = new Size(365, 82);
            buttonStats.TabIndex = 6;
            buttonStats.UseVisualStyleBackColor = false;
            buttonStats.Click += buttonStats_Click;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.White;
            buttonExit.FlatAppearance.BorderColor = Color.FromArgb(220, 38, 38);
            buttonExit.FlatAppearance.BorderSize = 2;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Location = new Point(62, 370);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(762, 82);
            buttonExit.TabIndex = 7;
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // lblAddExpenseTitle
            // 
            lblAddExpenseTitle.AutoSize = true;
            lblAddExpenseTitle.BackColor = Color.White;
            lblAddExpenseTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAddExpenseTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblAddExpenseTitle.Location = new Point(86, 171);
            lblAddExpenseTitle.Name = "lblAddExpenseTitle";
            lblAddExpenseTitle.Size = new Size(78, 21);
            lblAddExpenseTitle.TabIndex = 8;
            lblAddExpenseTitle.Text = "지출 등록";
            lblAddExpenseTitle.Click += buttonAddExpense_Click;
            // 
            // lblAddExpenseDesc
            // 
            lblAddExpenseDesc.AutoSize = true;
            lblAddExpenseDesc.BackColor = Color.White;
            lblAddExpenseDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblAddExpenseDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblAddExpenseDesc.Location = new Point(88, 200);
            lblAddExpenseDesc.Name = "lblAddExpenseDesc";
            lblAddExpenseDesc.Size = new Size(212, 15);
            lblAddExpenseDesc.TabIndex = 9;
            lblAddExpenseDesc.Text = "금액, 카테고리, 결제수단, 메모를 기록";
            lblAddExpenseDesc.Click += buttonAddExpense_Click;
            // 
            // lblExpenseListTitle
            // 
            lblExpenseListTitle.AutoSize = true;
            lblExpenseListTitle.BackColor = Color.White;
            lblExpenseListTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblExpenseListTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblExpenseListTitle.Location = new Point(483, 171);
            lblExpenseListTitle.Name = "lblExpenseListTitle";
            lblExpenseListTitle.Size = new Size(117, 21);
            lblExpenseListTitle.TabIndex = 10;
            lblExpenseListTitle.Text = "지출 목록/검색";
            lblExpenseListTitle.Click += buttonExpenseList_Click;
            // 
            // lblExpenseListDesc
            // 
            lblExpenseListDesc.AutoSize = true;
            lblExpenseListDesc.BackColor = Color.White;
            lblExpenseListDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblExpenseListDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblExpenseListDesc.Location = new Point(485, 200);
            lblExpenseListDesc.Name = "lblExpenseListDesc";
            lblExpenseListDesc.Size = new Size(234, 15);
            lblExpenseListDesc.TabIndex = 11;
            lblExpenseListDesc.Text = "날짜, 카테고리, 결제수단 기준으로 조회";
            lblExpenseListDesc.Click += buttonExpenseList_Click;
            // 
            // lblManageExpenseTitle
            // 
            lblManageExpenseTitle.AutoSize = true;
            lblManageExpenseTitle.BackColor = Color.White;
            lblManageExpenseTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblManageExpenseTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblManageExpenseTitle.Location = new Point(86, 281);
            lblManageExpenseTitle.Name = "lblManageExpenseTitle";
            lblManageExpenseTitle.Size = new Size(78, 21);
            lblManageExpenseTitle.TabIndex = 12;
            lblManageExpenseTitle.Text = "지출 관리";
            lblManageExpenseTitle.Click += buttonManageExpense_Click;
            // 
            // lblManageExpenseDesc
            // 
            lblManageExpenseDesc.AutoSize = true;
            lblManageExpenseDesc.BackColor = Color.White;
            lblManageExpenseDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblManageExpenseDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblManageExpenseDesc.Location = new Point(88, 310);
            lblManageExpenseDesc.Name = "lblManageExpenseDesc";
            lblManageExpenseDesc.Size = new Size(151, 15);
            lblManageExpenseDesc.TabIndex = 13;
            lblManageExpenseDesc.Text = "등록된 지출 수정 및 삭제";
            lblManageExpenseDesc.Click += buttonManageExpense_Click;
            // 
            // lblStatsTitle
            // 
            lblStatsTitle.AutoSize = true;
            lblStatsTitle.BackColor = Color.White;
            lblStatsTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblStatsTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblStatsTitle.Location = new Point(483, 281);
            lblStatsTitle.Name = "lblStatsTitle";
            lblStatsTitle.Size = new Size(78, 21);
            lblStatsTitle.TabIndex = 14;
            lblStatsTitle.Text = "지출 통계";
            lblStatsTitle.Click += buttonStats_Click;
            // 
            // lblStatsDesc
            // 
            lblStatsDesc.AutoSize = true;
            lblStatsDesc.BackColor = Color.White;
            lblStatsDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblStatsDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblStatsDesc.Location = new Point(485, 310);
            lblStatsDesc.Name = "lblStatsDesc";
            lblStatsDesc.Size = new Size(245, 15);
            lblStatsDesc.TabIndex = 15;
            lblStatsDesc.Text = "월별 합계와 카테고리별 소비 비율 확인";
            lblStatsDesc.Click += buttonStats_Click;
            // 
            // lblExitTitle
            // 
            lblExitTitle.AutoSize = true;
            lblExitTitle.BackColor = Color.White;
            lblExitTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblExitTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblExitTitle.Location = new Point(86, 391);
            lblExitTitle.Name = "lblExitTitle";
            lblExitTitle.Size = new Size(42, 21);
            lblExitTitle.TabIndex = 16;
            lblExitTitle.Text = "종료";
            lblExitTitle.Click += buttonExit_Click;
            // 
            // lblExitDesc
            // 
            lblExitDesc.AutoSize = true;
            lblExitDesc.BackColor = Color.White;
            lblExitDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblExitDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblExitDesc.Location = new Point(88, 420);
            lblExitDesc.Name = "lblExitDesc";
            lblExitDesc.Size = new Size(83, 15);
            lblExitDesc.TabIndex = 17;
            lblExitDesc.Text = "프로그램 닫기";
            lblExitDesc.Click += buttonExit_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(882, 553);
            Controls.Add(lblExitDesc);
            Controls.Add(lblExitTitle);
            Controls.Add(lblStatsDesc);
            Controls.Add(lblStatsTitle);
            Controls.Add(lblManageExpenseDesc);
            Controls.Add(lblManageExpenseTitle);
            Controls.Add(lblExpenseListDesc);
            Controls.Add(lblExpenseListTitle);
            Controls.Add(lblAddExpenseDesc);
            Controls.Add(lblAddExpenseTitle);
            Controls.Add(lblStatus);
            Controls.Add(buttonExit);
            Controls.Add(buttonStats);
            Controls.Add(buttonManageExpense);
            Controls.Add(buttonExpenseList);
            Controls.Add(buttonAddExpense);
            Controls.Add(lblToday);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MoneyNote - 개인 지출 관리";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblToday;
        private Label lblSubtitle;
        private Label lblStatus;
        private Button buttonAddExpense;
        private Button buttonExpenseList;
        private Button buttonManageExpense;
        private Button buttonStats;
        private Button buttonExit;
        private Label lblAddExpenseTitle;
        private Label lblAddExpenseDesc;
        private Label lblExpenseListTitle;
        private Label lblExpenseListDesc;
        private Label lblManageExpenseTitle;
        private Label lblManageExpenseDesc;
        private Label lblStatsTitle;
        private Label lblStatsDesc;
        private Label lblExitTitle;
        private Label lblExitDesc;
    }
}
