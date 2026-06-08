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
            panelDashboard = new Panel();
            lblAiCommentText = new Label();
            lblAiCommentTitle = new Label();
            panelRecentExpenses = new Panel();
            lblRecentExpense5 = new Label();
            lblRecentExpense4 = new Label();
            lblRecentExpense3 = new Label();
            lblRecentExpense2 = new Label();
            lblRecentExpense1 = new Label();
            lblRecentTitle = new Label();
            panelChartPreview = new Panel();
            lblChartFood = new Label();
            lblChartLife = new Label();
            lblChartTransport = new Label();
            lblChartEtc = new Label();
            barEtc = new Panel();
            barTransport = new Panel();
            barLife = new Panel();
            barFood = new Panel();
            lblChartTitle = new Label();
            panelTopCategory = new Panel();
            lblTopCategoryValue = new Label();
            lblTopCategoryCaption = new Label();
            panelFixedExpense = new Panel();
            lblFixedExpenseValue = new Label();
            lblFixedExpenseCaption = new Label();
            panelBudgetRate = new Panel();
            lblBudgetRateValue = new Label();
            lblBudgetRateCaption = new Label();
            panelMonthlyExpense = new Panel();
            lblMonthlyExpenseValue = new Label();
            lblMonthlyExpenseCaption = new Label();
            lblDashboardSubtitle = new Label();
            lblDashboardTitle = new Label();
            panelDashboard.SuspendLayout();
            panelRecentExpenses.SuspendLayout();
            panelChartPreview.SuspendLayout();
            panelTopCategory.SuspendLayout();
            panelFixedExpense.SuspendLayout();
            panelBudgetRate.SuspendLayout();
            panelMonthlyExpense.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(44, 34);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(205, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MoneyNote";
            // 
            // lblToday
            // 
            lblToday.BackColor = Color.White;
            lblToday.BorderStyle = BorderStyle.FixedSingle;
            lblToday.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblToday.ForeColor = Color.FromArgb(51, 65, 85);
            lblToday.Location = new Point(906, 44);
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
            lblSubtitle.Location = new Point(48, 88);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(380, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "지출을 기록하고 예산, 고정지출, 소비 흐름을 한눈에 확인합니다.";
            // 
            // buttonAddTask
            // 
            buttonAddTask.BackColor = Color.White;
            buttonAddTask.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
            buttonAddTask.FlatAppearance.BorderSize = 2;
            buttonAddTask.FlatStyle = FlatStyle.Flat;
            buttonAddTask.Location = new Point(48, 138);
            buttonAddTask.Name = "buttonAddTask";
            buttonAddTask.Size = new Size(365, 70);
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
            buttonTaskList.Location = new Point(48, 226);
            buttonTaskList.Name = "buttonTaskList";
            buttonTaskList.Size = new Size(365, 70);
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
            buttonEditTask.Location = new Point(48, 314);
            buttonEditTask.Name = "buttonEditTask";
            buttonEditTask.Size = new Size(365, 70);
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
            buttonSearch.Location = new Point(48, 402);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(365, 70);
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
            buttonStats.Location = new Point(48, 490);
            buttonStats.Name = "buttonStats";
            buttonStats.Size = new Size(174, 70);
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
            buttonExit.Location = new Point(239, 490);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(174, 70);
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
            lblAddTaskTitle.Location = new Point(72, 154);
            lblAddTaskTitle.Name = "lblAddTaskTitle";
            lblAddTaskTitle.Size = new Size(74, 21);
            lblAddTaskTitle.TabIndex = 9;
            lblAddTaskTitle.Text = "지출 등록";
            lblAddTaskTitle.Click += buttonAddTask_Click;
            // 
            // lblAddTaskDesc
            // 
            lblAddTaskDesc.AutoSize = true;
            lblAddTaskDesc.BackColor = Color.White;
            lblAddTaskDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblAddTaskDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblAddTaskDesc.Location = new Point(74, 183);
            lblAddTaskDesc.Name = "lblAddTaskDesc";
            lblAddTaskDesc.Size = new Size(216, 15);
            lblAddTaskDesc.TabIndex = 10;
            lblAddTaskDesc.Text = "금액, 카테고리, 결제수단, 메모를 기록";
            lblAddTaskDesc.Click += buttonAddTask_Click;
            // 
            // lblTaskListTitle
            // 
            lblTaskListTitle.AutoSize = true;
            lblTaskListTitle.BackColor = Color.White;
            lblTaskListTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTaskListTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblTaskListTitle.Location = new Point(72, 242);
            lblTaskListTitle.Name = "lblTaskListTitle";
            lblTaskListTitle.Size = new Size(74, 21);
            lblTaskListTitle.TabIndex = 11;
            lblTaskListTitle.Text = "지출 내역";
            lblTaskListTitle.Click += buttonTaskList_Click;
            // 
            // lblTaskListDesc
            // 
            lblTaskListDesc.AutoSize = true;
            lblTaskListDesc.BackColor = Color.White;
            lblTaskListDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblTaskListDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblTaskListDesc.Location = new Point(74, 271);
            lblTaskListDesc.Name = "lblTaskListDesc";
            lblTaskListDesc.Size = new Size(237, 15);
            lblTaskListDesc.TabIndex = 12;
            lblTaskListDesc.Text = "전체, 날짜별, 카테고리별 지출 조회와 검색";
            lblTaskListDesc.Click += buttonTaskList_Click;
            // 
            // lblEditTaskTitle
            // 
            lblEditTaskTitle.AutoSize = true;
            lblEditTaskTitle.BackColor = Color.White;
            lblEditTaskTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblEditTaskTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblEditTaskTitle.Location = new Point(72, 330);
            lblEditTaskTitle.Name = "lblEditTaskTitle";
            lblEditTaskTitle.Size = new Size(74, 21);
            lblEditTaskTitle.TabIndex = 13;
            lblEditTaskTitle.Text = "예산 관리";
            lblEditTaskTitle.Click += buttonEditTask_Click;
            // 
            // lblEditTaskDesc
            // 
            lblEditTaskDesc.AutoSize = true;
            lblEditTaskDesc.BackColor = Color.White;
            lblEditTaskDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblEditTaskDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblEditTaskDesc.Location = new Point(74, 359);
            lblEditTaskDesc.Name = "lblEditTaskDesc";
            lblEditTaskDesc.Size = new Size(215, 15);
            lblEditTaskDesc.TabIndex = 14;
            lblEditTaskDesc.Text = "월 예산과 카테고리별 예산을 설정";
            lblEditTaskDesc.Click += buttonEditTask_Click;
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.BackColor = Color.White;
            lblSearchTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblSearchTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblSearchTitle.Location = new Point(72, 418);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(74, 21);
            lblSearchTitle.TabIndex = 15;
            lblSearchTitle.Text = "고정지출";
            lblSearchTitle.Click += buttonSearch_Click;
            // 
            // lblSearchDesc
            // 
            lblSearchDesc.AutoSize = true;
            lblSearchDesc.BackColor = Color.White;
            lblSearchDesc.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblSearchDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblSearchDesc.Location = new Point(74, 447);
            lblSearchDesc.Name = "lblSearchDesc";
            lblSearchDesc.Size = new Size(237, 15);
            lblSearchDesc.TabIndex = 16;
            lblSearchDesc.Text = "구독료, 통신비처럼 반복되는 지출 관리";
            lblSearchDesc.Click += buttonSearch_Click;
            // 
            // lblStatsTitle
            // 
            lblStatsTitle.AutoSize = true;
            lblStatsTitle.BackColor = Color.White;
            lblStatsTitle.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblStatsTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblStatsTitle.Location = new Point(67, 507);
            lblStatsTitle.Name = "lblStatsTitle";
            lblStatsTitle.Size = new Size(69, 20);
            lblStatsTitle.TabIndex = 17;
            lblStatsTitle.Text = "소비 분석";
            lblStatsTitle.Click += buttonStats_Click;
            // 
            // lblStatsDesc
            // 
            lblStatsDesc.AutoSize = true;
            lblStatsDesc.BackColor = Color.White;
            lblStatsDesc.Font = new Font("맑은 고딕", 8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblStatsDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblStatsDesc.Location = new Point(69, 535);
            lblStatsDesc.Name = "lblStatsDesc";
            lblStatsDesc.Size = new Size(90, 13);
            lblStatsDesc.TabIndex = 18;
            lblStatsDesc.Text = "차트와 AI 코멘트";
            lblStatsDesc.Click += buttonStats_Click;
            // 
            // lblExitTitle
            // 
            lblExitTitle.AutoSize = true;
            lblExitTitle.BackColor = Color.White;
            lblExitTitle.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblExitTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblExitTitle.Location = new Point(258, 507);
            lblExitTitle.Name = "lblExitTitle";
            lblExitTitle.Size = new Size(39, 20);
            lblExitTitle.TabIndex = 19;
            lblExitTitle.Text = "종료";
            lblExitTitle.Click += buttonExit_Click;
            // 
            // lblExitDesc
            // 
            lblExitDesc.AutoSize = true;
            lblExitDesc.BackColor = Color.White;
            lblExitDesc.Font = new Font("맑은 고딕", 8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblExitDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblExitDesc.Location = new Point(260, 535);
            lblExitDesc.Name = "lblExitDesc";
            lblExitDesc.Size = new Size(87, 13);
            lblExitDesc.TabIndex = 20;
            lblExitDesc.Text = "프로그램 닫기";
            lblExitDesc.Click += buttonExit_Click;
            // 
            // panelDashboard
            // 
            panelDashboard.BackColor = Color.White;
            panelDashboard.BorderStyle = BorderStyle.FixedSingle;
            panelDashboard.Controls.Add(lblAiCommentText);
            panelDashboard.Controls.Add(lblAiCommentTitle);
            panelDashboard.Controls.Add(panelRecentExpenses);
            panelDashboard.Controls.Add(panelChartPreview);
            panelDashboard.Controls.Add(panelTopCategory);
            panelDashboard.Controls.Add(panelFixedExpense);
            panelDashboard.Controls.Add(panelBudgetRate);
            panelDashboard.Controls.Add(panelMonthlyExpense);
            panelDashboard.Controls.Add(lblDashboardSubtitle);
            panelDashboard.Controls.Add(lblDashboardTitle);
            panelDashboard.Location = new Point(448, 138);
            panelDashboard.Name = "panelDashboard";
            panelDashboard.Size = new Size(688, 460);
            panelDashboard.TabIndex = 22;
            // 
            // lblAiCommentText
            // 
            lblAiCommentText.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblAiCommentText.ForeColor = Color.FromArgb(71, 85, 105);
            lblAiCommentText.Location = new Point(31, 414);
            lblAiCommentText.Name = "lblAiCommentText";
            lblAiCommentText.Size = new Size(617, 22);
            lblAiCommentText.TabIndex = 9;
            lblAiCommentText.Text = "식비 비중이 높습니다. 예산 연결 후 실제 소비 흐름을 분석합니다.";
            lblAiCommentText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAiCommentTitle
            // 
            lblAiCommentTitle.AutoSize = true;
            lblAiCommentTitle.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAiCommentTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblAiCommentTitle.Location = new Point(29, 387);
            lblAiCommentTitle.Name = "lblAiCommentTitle";
            lblAiCommentTitle.Size = new Size(117, 20);
            lblAiCommentTitle.TabIndex = 8;
            lblAiCommentTitle.Text = "AI 소비 코멘트";
            // 
            // panelRecentExpenses
            // 
            panelRecentExpenses.BackColor = Color.FromArgb(248, 250, 252);
            panelRecentExpenses.BorderStyle = BorderStyle.FixedSingle;
            panelRecentExpenses.Controls.Add(lblRecentExpense5);
            panelRecentExpenses.Controls.Add(lblRecentExpense4);
            panelRecentExpenses.Controls.Add(lblRecentExpense3);
            panelRecentExpenses.Controls.Add(lblRecentExpense2);
            panelRecentExpenses.Controls.Add(lblRecentExpense1);
            panelRecentExpenses.Controls.Add(lblRecentTitle);
            panelRecentExpenses.Location = new Point(29, 220);
            panelRecentExpenses.Name = "panelRecentExpenses";
            panelRecentExpenses.Size = new Size(306, 170);
            panelRecentExpenses.TabIndex = 6;
            // 
            // lblRecentExpense5
            // 
            lblRecentExpense5.AutoSize = true;
            lblRecentExpense5.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblRecentExpense5.ForeColor = Color.FromArgb(71, 85, 105);
            lblRecentExpense5.Location = new Point(20, 135);
            lblRecentExpense5.Name = "lblRecentExpense5";
            lblRecentExpense5.Size = new Size(139, 15);
            lblRecentExpense5.TabIndex = 5;
            lblRecentExpense5.Text = "구독료 정기결제 9,900원";
            // 
            // lblRecentExpense4
            // 
            lblRecentExpense4.AutoSize = true;
            lblRecentExpense4.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblRecentExpense4.ForeColor = Color.FromArgb(71, 85, 105);
            lblRecentExpense4.Location = new Point(20, 111);
            lblRecentExpense4.Name = "lblRecentExpense4";
            lblRecentExpense4.Size = new Size(126, 15);
            lblRecentExpense4.TabIndex = 4;
            lblRecentExpense4.Text = "편의점 간식 3,800원";
            // 
            // lblRecentExpense3
            // 
            lblRecentExpense3.AutoSize = true;
            lblRecentExpense3.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblRecentExpense3.ForeColor = Color.FromArgb(71, 85, 105);
            lblRecentExpense3.Location = new Point(20, 87);
            lblRecentExpense3.Name = "lblRecentExpense3";
            lblRecentExpense3.Size = new Size(127, 15);
            lblRecentExpense3.TabIndex = 3;
            lblRecentExpense3.Text = "버스 교통비 1,500원";
            // 
            // lblRecentExpense2
            // 
            lblRecentExpense2.AutoSize = true;
            lblRecentExpense2.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblRecentExpense2.ForeColor = Color.FromArgb(71, 85, 105);
            lblRecentExpense2.Location = new Point(20, 63);
            lblRecentExpense2.Name = "lblRecentExpense2";
            lblRecentExpense2.Size = new Size(124, 15);
            lblRecentExpense2.TabIndex = 2;
            lblRecentExpense2.Text = "카페 아메리카노 5,200원";
            // 
            // lblRecentExpense1
            // 
            lblRecentExpense1.AutoSize = true;
            lblRecentExpense1.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblRecentExpense1.ForeColor = Color.FromArgb(71, 85, 105);
            lblRecentExpense1.Location = new Point(20, 39);
            lblRecentExpense1.Name = "lblRecentExpense1";
            lblRecentExpense1.Size = new Size(125, 15);
            lblRecentExpense1.TabIndex = 1;
            lblRecentExpense1.Text = "김밥천국 점심 8,500원";
            // 
            // lblRecentTitle
            // 
            lblRecentTitle.AutoSize = true;
            lblRecentTitle.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblRecentTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblRecentTitle.Location = new Point(18, 13);
            lblRecentTitle.Name = "lblRecentTitle";
            lblRecentTitle.Size = new Size(79, 19);
            lblRecentTitle.TabIndex = 0;
            lblRecentTitle.Text = "최근 지출";
            // 
            // panelChartPreview
            // 
            panelChartPreview.BackColor = Color.FromArgb(248, 250, 252);
            panelChartPreview.BorderStyle = BorderStyle.FixedSingle;
            panelChartPreview.Controls.Add(lblChartFood);
            panelChartPreview.Controls.Add(lblChartLife);
            panelChartPreview.Controls.Add(lblChartTransport);
            panelChartPreview.Controls.Add(lblChartEtc);
            panelChartPreview.Controls.Add(barEtc);
            panelChartPreview.Controls.Add(barTransport);
            panelChartPreview.Controls.Add(barLife);
            panelChartPreview.Controls.Add(barFood);
            panelChartPreview.Controls.Add(lblChartTitle);
            panelChartPreview.Location = new Point(356, 220);
            panelChartPreview.Name = "panelChartPreview";
            panelChartPreview.Size = new Size(292, 170);
            panelChartPreview.TabIndex = 7;
            // 
            // lblChartFood
            // 
            lblChartFood.AutoSize = true;
            lblChartFood.Font = new Font("맑은 고딕", 8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblChartFood.ForeColor = Color.FromArgb(71, 85, 105);
            lblChartFood.Location = new Point(21, 46);
            lblChartFood.Name = "lblChartFood";
            lblChartFood.Size = new Size(54, 13);
            lblChartFood.TabIndex = 8;
            lblChartFood.Text = "식비 42%";
            // 
            // lblChartLife
            // 
            lblChartLife.AutoSize = true;
            lblChartLife.Font = new Font("맑은 고딕", 8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblChartLife.ForeColor = Color.FromArgb(71, 85, 105);
            lblChartLife.Location = new Point(21, 74);
            lblChartLife.Name = "lblChartLife";
            lblChartLife.Size = new Size(54, 13);
            lblChartLife.TabIndex = 7;
            lblChartLife.Text = "생활 23%";
            // 
            // lblChartTransport
            // 
            lblChartTransport.AutoSize = true;
            lblChartTransport.Font = new Font("맑은 고딕", 8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblChartTransport.ForeColor = Color.FromArgb(71, 85, 105);
            lblChartTransport.Location = new Point(21, 102);
            lblChartTransport.Name = "lblChartTransport";
            lblChartTransport.Size = new Size(54, 13);
            lblChartTransport.TabIndex = 6;
            lblChartTransport.Text = "교통 18%";
            // 
            // lblChartEtc
            // 
            lblChartEtc.AutoSize = true;
            lblChartEtc.Font = new Font("맑은 고딕", 8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblChartEtc.ForeColor = Color.FromArgb(71, 85, 105);
            lblChartEtc.Location = new Point(21, 130);
            lblChartEtc.Name = "lblChartEtc";
            lblChartEtc.Size = new Size(54, 13);
            lblChartEtc.TabIndex = 5;
            lblChartEtc.Text = "기타 17%";
            // 
            // barEtc
            // 
            barEtc.BackColor = Color.FromArgb(148, 163, 184);
            barEtc.Location = new Point(93, 131);
            barEtc.Name = "barEtc";
            barEtc.Size = new Size(74, 11);
            barEtc.TabIndex = 4;
            // 
            // barTransport
            // 
            barTransport.BackColor = Color.FromArgb(5, 150, 105);
            barTransport.Location = new Point(93, 103);
            barTransport.Name = "barTransport";
            barTransport.Size = new Size(80, 11);
            barTransport.TabIndex = 3;
            // 
            // barLife
            // 
            barLife.BackColor = Color.FromArgb(234, 88, 12);
            barLife.Location = new Point(93, 75);
            barLife.Name = "barLife";
            barLife.Size = new Size(105, 11);
            barLife.TabIndex = 2;
            // 
            // barFood
            // 
            barFood.BackColor = Color.FromArgb(37, 99, 235);
            barFood.Location = new Point(93, 47);
            barFood.Name = "barFood";
            barFood.Size = new Size(158, 11);
            barFood.TabIndex = 1;
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblChartTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblChartTitle.Location = new Point(18, 13);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Size = new Size(107, 19);
            lblChartTitle.TabIndex = 0;
            lblChartTitle.Text = "카테고리 요약";
            // 
            // panelTopCategory
            // 
            panelTopCategory.BackColor = Color.FromArgb(255, 247, 237);
            panelTopCategory.BorderStyle = BorderStyle.FixedSingle;
            panelTopCategory.Controls.Add(lblTopCategoryValue);
            panelTopCategory.Controls.Add(lblTopCategoryCaption);
            panelTopCategory.Location = new Point(509, 103);
            panelTopCategory.Name = "panelTopCategory";
            panelTopCategory.Size = new Size(139, 104);
            panelTopCategory.TabIndex = 5;
            // 
            // lblTopCategoryValue
            // 
            lblTopCategoryValue.AutoSize = true;
            lblTopCategoryValue.Font = new Font("맑은 고딕", 15F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblTopCategoryValue.ForeColor = Color.FromArgb(154, 52, 18);
            lblTopCategoryValue.Location = new Point(18, 46);
            lblTopCategoryValue.Name = "lblTopCategoryValue";
            lblTopCategoryValue.Size = new Size(52, 28);
            lblTopCategoryValue.TabIndex = 1;
            lblTopCategoryValue.Text = "식비";
            // 
            // lblTopCategoryCaption
            // 
            lblTopCategoryCaption.AutoSize = true;
            lblTopCategoryCaption.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblTopCategoryCaption.ForeColor = Color.FromArgb(124, 45, 18);
            lblTopCategoryCaption.Location = new Point(16, 16);
            lblTopCategoryCaption.Name = "lblTopCategoryCaption";
            lblTopCategoryCaption.Size = new Size(84, 15);
            lblTopCategoryCaption.TabIndex = 0;
            lblTopCategoryCaption.Text = "최다 카테고리";
            // 
            // panelFixedExpense
            // 
            panelFixedExpense.BackColor = Color.FromArgb(240, 253, 250);
            panelFixedExpense.BorderStyle = BorderStyle.FixedSingle;
            panelFixedExpense.Controls.Add(lblFixedExpenseValue);
            panelFixedExpense.Controls.Add(lblFixedExpenseCaption);
            panelFixedExpense.Location = new Point(349, 103);
            panelFixedExpense.Name = "panelFixedExpense";
            panelFixedExpense.Size = new Size(139, 104);
            panelFixedExpense.TabIndex = 4;
            // 
            // lblFixedExpenseValue
            // 
            lblFixedExpenseValue.AutoSize = true;
            lblFixedExpenseValue.Font = new Font("맑은 고딕", 15F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblFixedExpenseValue.ForeColor = Color.FromArgb(15, 118, 110);
            lblFixedExpenseValue.Location = new Point(16, 46);
            lblFixedExpenseValue.Name = "lblFixedExpenseValue";
            lblFixedExpenseValue.Size = new Size(91, 28);
            lblFixedExpenseValue.TabIndex = 1;
            lblFixedExpenseValue.Text = "52,000원";
            // 
            // lblFixedExpenseCaption
            // 
            lblFixedExpenseCaption.AutoSize = true;
            lblFixedExpenseCaption.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblFixedExpenseCaption.ForeColor = Color.FromArgb(17, 94, 89);
            lblFixedExpenseCaption.Location = new Point(16, 16);
            lblFixedExpenseCaption.Name = "lblFixedExpenseCaption";
            lblFixedExpenseCaption.Size = new Size(83, 15);
            lblFixedExpenseCaption.TabIndex = 0;
            lblFixedExpenseCaption.Text = "이번 달 고정";
            // 
            // panelBudgetRate
            // 
            panelBudgetRate.BackColor = Color.FromArgb(239, 246, 255);
            panelBudgetRate.BorderStyle = BorderStyle.FixedSingle;
            panelBudgetRate.Controls.Add(lblBudgetRateValue);
            panelBudgetRate.Controls.Add(lblBudgetRateCaption);
            panelBudgetRate.Location = new Point(189, 103);
            panelBudgetRate.Name = "panelBudgetRate";
            panelBudgetRate.Size = new Size(139, 104);
            panelBudgetRate.TabIndex = 3;
            // 
            // lblBudgetRateValue
            // 
            lblBudgetRateValue.AutoSize = true;
            lblBudgetRateValue.Font = new Font("맑은 고딕", 15F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblBudgetRateValue.ForeColor = Color.FromArgb(29, 78, 216);
            lblBudgetRateValue.Location = new Point(18, 46);
            lblBudgetRateValue.Name = "lblBudgetRateValue";
            lblBudgetRateValue.Size = new Size(48, 28);
            lblBudgetRateValue.TabIndex = 1;
            lblBudgetRateValue.Text = "61%";
            // 
            // lblBudgetRateCaption
            // 
            lblBudgetRateCaption.AutoSize = true;
            lblBudgetRateCaption.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblBudgetRateCaption.ForeColor = Color.FromArgb(30, 64, 175);
            lblBudgetRateCaption.Location = new Point(16, 16);
            lblBudgetRateCaption.Name = "lblBudgetRateCaption";
            lblBudgetRateCaption.Size = new Size(72, 15);
            lblBudgetRateCaption.TabIndex = 0;
            lblBudgetRateCaption.Text = "예산 사용률";
            // 
            // panelMonthlyExpense
            // 
            panelMonthlyExpense.BackColor = Color.FromArgb(248, 250, 252);
            panelMonthlyExpense.BorderStyle = BorderStyle.FixedSingle;
            panelMonthlyExpense.Controls.Add(lblMonthlyExpenseValue);
            panelMonthlyExpense.Controls.Add(lblMonthlyExpenseCaption);
            panelMonthlyExpense.Location = new Point(29, 103);
            panelMonthlyExpense.Name = "panelMonthlyExpense";
            panelMonthlyExpense.Size = new Size(139, 104);
            panelMonthlyExpense.TabIndex = 2;
            // 
            // lblMonthlyExpenseValue
            // 
            lblMonthlyExpenseValue.Font = new Font("맑은 고딕", 15F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblMonthlyExpenseValue.ForeColor = Color.FromArgb(15, 23, 42);
            lblMonthlyExpenseValue.Location = new Point(0, 44);
            lblMonthlyExpenseValue.Name = "lblMonthlyExpenseValue";
            lblMonthlyExpenseValue.Size = new Size(137, 34);
            lblMonthlyExpenseValue.TabIndex = 1;
            lblMonthlyExpenseValue.Text = "184,500원";
            lblMonthlyExpenseValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMonthlyExpenseCaption
            // 
            lblMonthlyExpenseCaption.Font = new Font("맑은 고딕", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblMonthlyExpenseCaption.ForeColor = Color.FromArgb(71, 85, 105);
            lblMonthlyExpenseCaption.Location = new Point(0, 15);
            lblMonthlyExpenseCaption.Name = "lblMonthlyExpenseCaption";
            lblMonthlyExpenseCaption.Size = new Size(137, 18);
            lblMonthlyExpenseCaption.TabIndex = 0;
            lblMonthlyExpenseCaption.Text = "이번 달 지출";
            lblMonthlyExpenseCaption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDashboardSubtitle
            // 
            lblDashboardSubtitle.AutoSize = true;
            lblDashboardSubtitle.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblDashboardSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblDashboardSubtitle.Location = new Point(32, 58);
            lblDashboardSubtitle.Name = "lblDashboardSubtitle";
            lblDashboardSubtitle.Size = new Size(342, 15);
            lblDashboardSubtitle.TabIndex = 1;
            lblDashboardSubtitle.Text = "DB 연결 후 실제 월별 지출, 예산, 고정지출 데이터를 표시합니다.";
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("맑은 고딕", 16F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblDashboardTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblDashboardTitle.Location = new Point(29, 23);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(153, 30);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "이번 달 한눈에";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1184, 631);
            Controls.Add(panelDashboard);
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
            Text = "MoneyNote - 개인 지출 관리";
            panelDashboard.ResumeLayout(false);
            panelDashboard.PerformLayout();
            panelRecentExpenses.ResumeLayout(false);
            panelRecentExpenses.PerformLayout();
            panelChartPreview.ResumeLayout(false);
            panelChartPreview.PerformLayout();
            panelTopCategory.ResumeLayout(false);
            panelTopCategory.PerformLayout();
            panelFixedExpense.ResumeLayout(false);
            panelFixedExpense.PerformLayout();
            panelBudgetRate.ResumeLayout(false);
            panelBudgetRate.PerformLayout();
            panelMonthlyExpense.ResumeLayout(false);
            panelMonthlyExpense.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblToday;
        private Label lblSubtitle;
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
        private Panel panelDashboard;
        private Label lblDashboardTitle;
        private Label lblDashboardSubtitle;
        private Panel panelMonthlyExpense;
        private Label lblMonthlyExpenseCaption;
        private Label lblMonthlyExpenseValue;
        private Panel panelBudgetRate;
        private Label lblBudgetRateValue;
        private Label lblBudgetRateCaption;
        private Panel panelFixedExpense;
        private Label lblFixedExpenseValue;
        private Label lblFixedExpenseCaption;
        private Panel panelTopCategory;
        private Label lblTopCategoryValue;
        private Label lblTopCategoryCaption;
        private Panel panelRecentExpenses;
        private Label lblRecentTitle;
        private Label lblRecentExpense1;
        private Label lblRecentExpense2;
        private Label lblRecentExpense3;
        private Label lblRecentExpense4;
        private Label lblRecentExpense5;
        private Panel panelChartPreview;
        private Label lblChartTitle;
        private Panel barFood;
        private Panel barLife;
        private Panel barTransport;
        private Panel barEtc;
        private Label lblChartEtc;
        private Label lblChartTransport;
        private Label lblChartLife;
        private Label lblChartFood;
        private Label lblAiCommentTitle;
        private Label lblAiCommentText;
    }
}
