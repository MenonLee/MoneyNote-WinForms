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
            buttonAddTask = new Button();
            buttonTaskList = new Button();
            buttonEditTask = new Button();
            buttonSearch = new Button();
            buttonStats = new Button();
            buttonExit = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("맑은 고딕", 22F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(58, 42);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(363, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "개인 일정 및 과제 관리";
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
            lblSubtitle.Location = new Point(62, 91);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(361, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "일정 등록, 조회, 관리, 검색, 통계를 한 곳에서 확인합니다.";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
            lblStatus.Location = new Point(62, 507);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(212, 15);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "DB 초기화 후 각 기능 화면으로 이동합니다.";
            // 
            // buttonAddTask
            // 
            buttonAddTask.BackColor = Color.White;
            buttonAddTask.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
            buttonAddTask.FlatAppearance.BorderSize = 2;
            buttonAddTask.FlatStyle = FlatStyle.Flat;
            buttonAddTask.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonAddTask.ForeColor = Color.FromArgb(30, 41, 59);
            buttonAddTask.Location = new Point(62, 150);
            buttonAddTask.Name = "buttonAddTask";
            buttonAddTask.Size = new Size(365, 82);
            buttonAddTask.TabIndex = 3;
            buttonAddTask.Text = "일정 등록";
            buttonAddTask.TextAlign = ContentAlignment.MiddleLeft;
            buttonAddTask.UseVisualStyleBackColor = false;
            buttonAddTask.Click += buttonAddTask_Click;
            // 
            // buttonTaskList
            // 
            buttonTaskList.BackColor = Color.White;
            buttonTaskList.FlatAppearance.BorderColor = Color.FromArgb(5, 150, 105);
            buttonTaskList.FlatAppearance.BorderSize = 2;
            buttonTaskList.FlatStyle = FlatStyle.Flat;
            buttonTaskList.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonTaskList.ForeColor = Color.FromArgb(30, 41, 59);
            buttonTaskList.Location = new Point(459, 150);
            buttonTaskList.Name = "buttonTaskList";
            buttonTaskList.Size = new Size(365, 82);
            buttonTaskList.TabIndex = 4;
            buttonTaskList.Text = "일정 목록";
            buttonTaskList.TextAlign = ContentAlignment.MiddleLeft;
            buttonTaskList.UseVisualStyleBackColor = false;
            buttonTaskList.Click += buttonTaskList_Click;
            // 
            // buttonEditTask
            // 
            buttonEditTask.BackColor = Color.White;
            buttonEditTask.FlatAppearance.BorderColor = Color.FromArgb(234, 88, 12);
            buttonEditTask.FlatAppearance.BorderSize = 2;
            buttonEditTask.FlatStyle = FlatStyle.Flat;
            buttonEditTask.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonEditTask.ForeColor = Color.FromArgb(30, 41, 59);
            buttonEditTask.Location = new Point(62, 257);
            buttonEditTask.Name = "buttonEditTask";
            buttonEditTask.Size = new Size(365, 82);
            buttonEditTask.TabIndex = 5;
            buttonEditTask.Text = "일정 관리";
            buttonEditTask.TextAlign = ContentAlignment.MiddleLeft;
            buttonEditTask.UseVisualStyleBackColor = false;
            buttonEditTask.Click += buttonEditTask_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.White;
            buttonSearch.FlatAppearance.BorderColor = Color.FromArgb(124, 58, 237);
            buttonSearch.FlatAppearance.BorderSize = 2;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonSearch.ForeColor = Color.FromArgb(30, 41, 59);
            buttonSearch.Location = new Point(459, 257);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(365, 82);
            buttonSearch.TabIndex = 6;
            buttonSearch.Text = "검색";
            buttonSearch.TextAlign = ContentAlignment.MiddleLeft;
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonStats
            // 
            buttonStats.BackColor = Color.White;
            buttonStats.FlatAppearance.BorderColor = Color.FromArgb(100, 116, 139);
            buttonStats.FlatAppearance.BorderSize = 2;
            buttonStats.FlatStyle = FlatStyle.Flat;
            buttonStats.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonStats.ForeColor = Color.FromArgb(30, 41, 59);
            buttonStats.Location = new Point(62, 364);
            buttonStats.Name = "buttonStats";
            buttonStats.Size = new Size(365, 82);
            buttonStats.TabIndex = 7;
            buttonStats.Text = "통계";
            buttonStats.TextAlign = ContentAlignment.MiddleLeft;
            buttonStats.UseVisualStyleBackColor = false;
            buttonStats.Click += buttonStats_Click;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.White;
            buttonExit.FlatAppearance.BorderColor = Color.FromArgb(220, 38, 38);
            buttonExit.FlatAppearance.BorderSize = 2;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonExit.ForeColor = Color.FromArgb(30, 41, 59);
            buttonExit.Location = new Point(459, 364);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(365, 82);
            buttonExit.TabIndex = 8;
            buttonExit.Text = "종료";
            buttonExit.TextAlign = ContentAlignment.MiddleLeft;
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(882, 553);
            Controls.Add(lblStatus);
            Controls.Add(buttonExit);
            Controls.Add(buttonStats);
            Controls.Add(buttonSearch);
            Controls.Add(buttonEditTask);
            Controls.Add(buttonTaskList);
            Controls.Add(buttonAddTask);
            Controls.Add(lblToday);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "개인 일정 및 과제 관리 프로그램";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblToday;
        private Label lblSubtitle;
        private Label lblStatus;
        private Button buttonAddTask;
        private Button buttonTaskList;
        private Button buttonEditTask;
        private Button buttonSearch;
        private Button buttonStats;
        private Button buttonExit;
    }
}
