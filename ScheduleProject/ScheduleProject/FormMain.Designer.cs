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
            lblTitle.Font = new Font("맑은 고딕", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTitle.Location = new Point(150, 50);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(600, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "개인 일정 및 과제 관리 프로그램";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblToday
            // 
            lblToday.Font = new Font("맑은 고딕", 11F);
            lblToday.Location = new Point(250, 110);
            lblToday.Name = "lblToday";
            lblToday.Size = new Size(400, 30);
            lblToday.TabIndex = 1;
            lblToday.Text = "오늘 날짜: ";
            lblToday.TextAlign = ContentAlignment.MiddleCenter;            
            // 
            // buttonAddTask
            // 
            buttonAddTask.Font = new Font("맑은 고딕", 11F);
            buttonAddTask.Location = new Point(360, 180);
            buttonAddTask.Name = "buttonAddTask";
            buttonAddTask.Size = new Size(180, 45);
            buttonAddTask.TabIndex = 2;
            buttonAddTask.Text = "일정 등록";
            buttonAddTask.UseVisualStyleBackColor = true;
            buttonAddTask.Click += buttonAddTask_Click;
            // 
            // buttonTaskList
            // 
            buttonTaskList.Font = new Font("맑은 고딕", 11F);
            buttonTaskList.Location = new Point(360, 240);
            buttonTaskList.Name = "buttonTaskList";
            buttonTaskList.Size = new Size(180, 45);
            buttonTaskList.TabIndex = 3;
            buttonTaskList.Text = "일정 목록";
            buttonTaskList.UseVisualStyleBackColor = true;
            buttonTaskList.Click += buttonTaskList_Click;
            // 
            // buttonEditTask
            // 
            buttonEditTask.Font = new Font("맑은 고딕", 11F);
            buttonEditTask.Location = new Point(360, 300);
            buttonEditTask.Name = "buttonEditTask";
            buttonEditTask.Size = new Size(180, 45);
            buttonEditTask.TabIndex = 4;
            buttonEditTask.Text = "수정 / 삭제";
            buttonEditTask.UseVisualStyleBackColor = true;
            buttonEditTask.Click += buttonEditTask_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Font = new Font("맑은 고딕", 11F);
            buttonSearch.Location = new Point(360, 360);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(180, 45);
            buttonSearch.TabIndex = 5;
            buttonSearch.Text = "검색";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonStats
            // 
            buttonStats.Font = new Font("맑은 고딕", 11F);
            buttonStats.Location = new Point(360, 420);
            buttonStats.Name = "buttonStats";
            buttonStats.Size = new Size(180, 45);
            buttonStats.TabIndex = 6;
            buttonStats.Text = "통계";
            buttonStats.UseVisualStyleBackColor = true;
            buttonStats.Click += buttonStats_Click;
            // 
            // buttonExit
            // 
            buttonExit.Font = new Font("맑은 고딕", 11F);
            buttonExit.Location = new Point(360, 480);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(180, 45);
            buttonExit.TabIndex = 7;
            buttonExit.Text = "종료";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(882, 553);
            Controls.Add(buttonExit);
            Controls.Add(buttonStats);
            Controls.Add(buttonSearch);
            Controls.Add(buttonEditTask);
            Controls.Add(buttonTaskList);
            Controls.Add(buttonAddTask);
            Controls.Add(lblToday);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "개인 일정 및 과제 관리 프로그램";
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblToday;
        private Button buttonAddTask;
        private Button buttonTaskList;
        private Button buttonEditTask;
        private Button buttonSearch;
        private Button buttonStats;
        private Button buttonExit;
    }
}
