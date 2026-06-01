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
            lblAddTaskTitle = new Label();
            lblAddTaskDesc = new Label();
            lblTaskListTitle = new Label();
            lblTaskListDesc = new Label();
            lblEditTaskTitle = new Label();
            lblEditTaskDesc = new Label();
            lblSearchTitle = new Label();
            lblSearchDesc = new Label();
            lblStatsTitle = new Label();
            lblStatsDesc = new Label();
            lblExitTitle = new Label();
            lblExitDesc = new Label();
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
            lblStatus.TabIndex = 21;
            lblStatus.Text = "DB 초기화 후 각 기능 화면으로 이동합니다.";
            // 
            // buttonAddTask
            // 
            buttonAddTask.BackColor = Color.White;
            buttonAddTask.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
            buttonAddTask.FlatAppearance.BorderSize = 2;
            buttonAddTask.FlatStyle = FlatStyle.Flat;
            buttonAddTask.Location = new Point(62, 150);
            buttonAddTask.Name = "buttonAddTask";
            buttonAddTask.Size = new Size(365, 82);
            buttonAddTask.TabIndex = 3;
            buttonAddTask.UseVisualStyleBackColor = false;
            buttonAddTask.Click += buttonAddTask_Click;
            // 
            // buttonTaskList
            // 
            buttonTaskList.BackColor = Color.White;
            buttonTaskList.FlatAppearance.BorderColor = Color.FromArgb(5, 150, 105);
            buttonTaskList.FlatAppearance.BorderSize = 2;
            buttonTaskList.FlatStyle = FlatStyle.Flat;
            buttonTaskList.Location = new Point(459, 150);
            buttonTaskList.Name = "buttonTaskList";
            buttonTaskList.Size = new Size(365, 82);
            buttonTaskList.TabIndex = 4;
            buttonTaskList.UseVisualStyleBackColor = false;
            buttonTaskList.Click += buttonTaskList_Click;
            // 
            // buttonEditTask
            // 
            buttonEditTask.BackColor = Color.White;
            buttonEditTask.FlatAppearance.BorderColor = Color.FromArgb(234, 88, 12);
            buttonEditTask.FlatAppearance.BorderSize = 2;
            buttonEditTask.FlatStyle = FlatStyle.Flat;
            buttonEditTask.Location = new Point(62, 257);
            buttonEditTask.Name = "buttonEditTask";
            buttonEditTask.Size = new Size(365, 82);
            buttonEditTask.TabIndex = 5;
            buttonEditTask.UseVisualStyleBackColor = false;
            buttonEditTask.Click += buttonEditTask_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.White;
            buttonSearch.FlatAppearance.BorderColor = Color.FromArgb(124, 58, 237);
            buttonSearch.FlatAppearance.BorderSize = 2;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Location = new Point(459, 257);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(365, 82);
            buttonSearch.TabIndex = 6;
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonStats
            // 
            buttonStats.BackColor = Color.White;
            buttonStats.FlatAppearance.BorderColor = Color.FromArgb(100, 116, 139);
            buttonStats.FlatAppearance.BorderSize = 2;
            buttonStats.FlatStyle = FlatStyle.Flat;
            buttonStats.Location = new Point(62, 364);
            buttonStats.Name = "buttonStats";
            buttonStats.Size = new Size(365, 82);
            buttonStats.TabIndex = 7;
            buttonStats.UseVisualStyleBackColor = false;
            buttonStats.Click += buttonStats_Click;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.White;
            buttonExit.FlatAppearance.BorderColor = Color.FromArgb(220, 38, 38);
            buttonExit.FlatAppearance.BorderSize = 2;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Location = new Point(459, 364);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(365, 82);
            buttonExit.TabIndex = 8;
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // lblAddTaskTitle
            // 
            lblAddTaskTitle.AutoSize = true;
            lblAddTaskTitle.BackColor = Color.White;
            lblAddTaskTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAddTaskTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblAddTaskTitle.Location = new Point(86, 171);
            lblAddTaskTitle.Name = "lblAddTaskTitle";
            lblAddTaskTitle.Size = new Size(78, 21);
            lblAddTaskTitle.TabIndex = 9;
            lblAddTaskTitle.Text = "일정 등록";
            lblAddTaskTitle.Click += buttonAddTask_Click;
            // 
            // lblAddTaskDesc
            // 
            lblAddTaskDesc.AutoSize = true;
            lblAddTaskDesc.BackColor = Color.White;
            lblAddTaskDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblAddTaskDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblAddTaskDesc.Location = new Point(88, 200);
            lblAddTaskDesc.Name = "lblAddTaskDesc";
            lblAddTaskDesc.Size = new Size(139, 15);
            lblAddTaskDesc.TabIndex = 10;
            lblAddTaskDesc.Text = "새 일정과 마감일을 추가";
            lblAddTaskDesc.Click += buttonAddTask_Click;
            // 
            // lblTaskListTitle
            // 
            lblTaskListTitle.AutoSize = true;
            lblTaskListTitle.BackColor = Color.White;
            lblTaskListTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTaskListTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblTaskListTitle.Location = new Point(483, 171);
            lblTaskListTitle.Name = "lblTaskListTitle";
            lblTaskListTitle.Size = new Size(78, 21);
            lblTaskListTitle.TabIndex = 11;
            lblTaskListTitle.Text = "일정 목록";
            lblTaskListTitle.Click += buttonTaskList_Click;
            // 
            // lblTaskListDesc
            // 
            lblTaskListDesc.AutoSize = true;
            lblTaskListDesc.BackColor = Color.White;
            lblTaskListDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblTaskListDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblTaskListDesc.Location = new Point(485, 200);
            lblTaskListDesc.Name = "lblTaskListDesc";
            lblTaskListDesc.Size = new Size(151, 15);
            lblTaskListDesc.TabIndex = 12;
            lblTaskListDesc.Text = "전체 및 날짜별 일정 확인";
            lblTaskListDesc.Click += buttonTaskList_Click;
            // 
            // lblEditTaskTitle
            // 
            lblEditTaskTitle.AutoSize = true;
            lblEditTaskTitle.BackColor = Color.White;
            lblEditTaskTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblEditTaskTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblEditTaskTitle.Location = new Point(86, 278);
            lblEditTaskTitle.Name = "lblEditTaskTitle";
            lblEditTaskTitle.Size = new Size(78, 21);
            lblEditTaskTitle.TabIndex = 13;
            lblEditTaskTitle.Text = "일정 관리";
            lblEditTaskTitle.Click += buttonEditTask_Click;
            // 
            // lblEditTaskDesc
            // 
            lblEditTaskDesc.AutoSize = true;
            lblEditTaskDesc.BackColor = Color.White;
            lblEditTaskDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblEditTaskDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblEditTaskDesc.Location = new Point(88, 307);
            lblEditTaskDesc.Name = "lblEditTaskDesc";
            lblEditTaskDesc.Size = new Size(126, 15);
            lblEditTaskDesc.TabIndex = 14;
            lblEditTaskDesc.Text = "수정, 삭제, 완료 처리";
            lblEditTaskDesc.Click += buttonEditTask_Click;
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.BackColor = Color.White;
            lblSearchTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblSearchTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblSearchTitle.Location = new Point(483, 278);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(42, 21);
            lblSearchTitle.TabIndex = 15;
            lblSearchTitle.Text = "검색";
            lblSearchTitle.Click += buttonSearch_Click;
            // 
            // lblSearchDesc
            // 
            lblSearchDesc.AutoSize = true;
            lblSearchDesc.BackColor = Color.White;
            lblSearchDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblSearchDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblSearchDesc.Location = new Point(485, 307);
            lblSearchDesc.Name = "lblSearchDesc";
            lblSearchDesc.Size = new Size(143, 15);
            lblSearchDesc.TabIndex = 16;
            lblSearchDesc.Text = "제목과 내용 기준으로 검색";
            lblSearchDesc.Click += buttonSearch_Click;
            // 
            // lblStatsTitle
            // 
            lblStatsTitle.AutoSize = true;
            lblStatsTitle.BackColor = Color.White;
            lblStatsTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblStatsTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblStatsTitle.Location = new Point(86, 385);
            lblStatsTitle.Name = "lblStatsTitle";
            lblStatsTitle.Size = new Size(42, 21);
            lblStatsTitle.TabIndex = 17;
            lblStatsTitle.Text = "통계";
            lblStatsTitle.Click += buttonStats_Click;
            // 
            // lblStatsDesc
            // 
            lblStatsDesc.AutoSize = true;
            lblStatsDesc.BackColor = Color.White;
            lblStatsDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblStatsDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblStatsDesc.Location = new Point(88, 414);
            lblStatsDesc.Name = "lblStatsDesc";
            lblStatsDesc.Size = new Size(151, 15);
            lblStatsDesc.TabIndex = 18;
            lblStatsDesc.Text = "완료 현황과 카테고리 집계";
            lblStatsDesc.Click += buttonStats_Click;
            // 
            // lblExitTitle
            // 
            lblExitTitle.AutoSize = true;
            lblExitTitle.BackColor = Color.White;
            lblExitTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblExitTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblExitTitle.Location = new Point(483, 385);
            lblExitTitle.Name = "lblExitTitle";
            lblExitTitle.Size = new Size(42, 21);
            lblExitTitle.TabIndex = 19;
            lblExitTitle.Text = "종료";
            lblExitTitle.Click += buttonExit_Click;
            // 
            // lblExitDesc
            // 
            lblExitDesc.AutoSize = true;
            lblExitDesc.BackColor = Color.White;
            lblExitDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblExitDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblExitDesc.Location = new Point(485, 414);
            lblExitDesc.Name = "lblExitDesc";
            lblExitDesc.Size = new Size(83, 15);
            lblExitDesc.TabIndex = 20;
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
            Controls.Add(lblSearchDesc);
            Controls.Add(lblSearchTitle);
            Controls.Add(lblEditTaskDesc);
            Controls.Add(lblEditTaskTitle);
            Controls.Add(lblTaskListDesc);
            Controls.Add(lblTaskListTitle);
            Controls.Add(lblAddTaskDesc);
            Controls.Add(lblAddTaskTitle);
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
        private Label lblAddTaskTitle;
        private Label lblAddTaskDesc;
        private Label lblTaskListTitle;
        private Label lblTaskListDesc;
        private Label lblEditTaskTitle;
        private Label lblEditTaskDesc;
        private Label lblSearchTitle;
        private Label lblSearchDesc;
        private Label lblStatsTitle;
        private Label lblStatsDesc;
        private Label lblExitTitle;
        private Label lblExitDesc;
    }
}
