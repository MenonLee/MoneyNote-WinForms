using System.Drawing;
using ScheduleProject.Data;
using ScheduleProject.Models;
using ScheduleProject.Services;

namespace ScheduleProject
{
    public partial class FormMain : Form
    {
        private readonly Color menuNormalColor = Color.White;
        private readonly Color menuHoverColor = Color.FromArgb(226, 232, 240);
        private readonly GrokService grokService = new GrokService();
        private bool isGeneratingAiComment;

        public FormMain()
        {
            InitializeComponent();

            lblToday.Text = "오늘 날짜: " + DateTime.Now.ToString("yyyy-MM-dd");
            InitializeMenuHoverEffects();
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;

            int monthlyExpense = DatabaseHelper.GetMonthlyExpenseAmount(year, month);
            int monthlyBudget = DatabaseHelper.GetMonthlyBudget(year, month);
            int fixedExpense = DatabaseHelper.GetTotalFixedExpenseAmount();
            var categorySpending = DatabaseHelper.GetCategorySpending(year, month);
            var categoryBudgets = DatabaseHelper.GetCategoryBudgets(year, month);
            var recentExpenses = DatabaseHelper.GetRecentExpenses(5);

            lblMonthlyExpenseValue.Text = FormatCurrency(monthlyExpense);
            lblBudgetRateValue.Text = monthlyBudget > 0
                ? $"{Math.Min(999, monthlyExpense * 100 / monthlyBudget)}%"
                : "미설정";
            lblFixedExpenseValue.Text = FormatCurrency(fixedExpense);
            lblTopCategoryValue.Text = categorySpending.Count > 0
                ? categorySpending.OrderByDescending(item => item.Value).First().Key
                : "-";

            UpdateRecentExpenses(recentExpenses);
            UpdateCategorySummary(categorySpending);

            string? aiComment = DatabaseHelper.GetLastAiAnalysis(year, month);
            if (string.IsNullOrWhiteSpace(aiComment))
            {
                var summary = new MonthlySpendingSummary
                {
                    Year = year,
                    Month = month,
                    TotalExpenseAmount = monthlyExpense,
                    MonthlyBudget = monthlyBudget,
                    FixedExpenseAmount = fixedExpense,
                    CategorySpending = categorySpending,
                    CategoryBudgets = categoryBudgets,
                    RecentExpenses = recentExpenses
                };
                GenerateAiCommentIfNeeded(summary);
            }
            else
            {
                lblAiCommentText.Text = aiComment;
            }
        }

        private async void GenerateAiCommentIfNeeded(MonthlySpendingSummary summary)
        {
            if (isGeneratingAiComment)
            {
                return;
            }

            if (summary.TotalExpenseAmount <= 0 && summary.RecentExpenses.Count == 0)
            {
                lblAiCommentText.Text = "이번 달 지출 데이터가 쌓이면 AI 소비 코멘트를 생성합니다.";
                return;
            }

            isGeneratingAiComment = true;
            lblAiCommentText.Text = "AI 소비 코멘트 생성 중...";

            try
            {
                string comment = await grokService.AnalyzeMonthlySpendingAsync(summary);
                DatabaseHelper.AddAiAnalysisLog(new AiAnalysisLog
                {
                    Year = summary.Year,
                    Month = summary.Month,
                    Summary = comment,
                    CreatedAt = DateTime.Now
                });
                lblAiCommentText.Text = comment;
            }
            catch (Exception ex)
            {
                lblAiCommentText.Text = $"AI 소비 코멘트를 생성하지 못했습니다. {ex.Message}";
            }
            finally
            {
                isGeneratingAiComment = false;
            }
        }

        private void UpdateRecentExpenses(List<ExpenseItem> recentExpenses)
        {
            Label[] labels =
            {
                lblRecentExpense1,
                lblRecentExpense2,
                lblRecentExpense3,
                lblRecentExpense4,
                lblRecentExpense5
            };

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = i < recentExpenses.Count
                    ? $"{recentExpenses[i].Title} {FormatCurrency(recentExpenses[i].Amount)}"
                    : "-";
            }
        }

        private void UpdateCategorySummary(Dictionary<string, int> categorySpending)
        {
            Label[] labels = { lblChartFood, lblChartLife, lblChartTransport, lblChartEtc };
            Panel[] bars = { barFood, barLife, barTransport, barEtc };
            int total = categorySpending.Values.Sum();
            const int maxBarWidth = 158;

            var topCategories = categorySpending
                .OrderByDescending(item => item.Value)
                .Take(labels.Length)
                .ToList();

            for (int i = 0; i < labels.Length; i++)
            {
                if (i >= topCategories.Count || total <= 0)
                {
                    labels[i].Text = "- 0%";
                    bars[i].Width = 0;
                    continue;
                }

                int percent = (int)Math.Round(topCategories[i].Value * 100.0 / total);
                labels[i].Text = $"{topCategories[i].Key} {percent}%";
                bars[i].Width = Math.Max(4, maxBarWidth * percent / 100);
            }
        }

        private static string FormatCurrency(int amount)
        {
            return amount.ToString("N0") + "원";
        }

        private void InitializeMenuHoverEffects()
        {
            ConfigureMenuHover(buttonAddTask, lblAddTaskTitle, lblAddTaskDesc);
            ConfigureMenuHover(buttonTaskList, lblTaskListTitle, lblTaskListDesc);
            ConfigureMenuHover(buttonEditTask, lblEditTaskTitle, lblEditTaskDesc);
            ConfigureMenuHover(buttonSearch, lblSearchTitle, lblSearchDesc);
            ConfigureMenuHover(buttonStats, lblStatsTitle, lblStatsDesc);
            ConfigureMenuHover(buttonExit, lblExitTitle, lblExitDesc);
        }

        private void ResetMenuColors()
        {
            SetMenuColor(buttonAddTask, new[] { lblAddTaskTitle, lblAddTaskDesc }, menuNormalColor);
            SetMenuColor(buttonTaskList, new[] { lblTaskListTitle, lblTaskListDesc }, menuNormalColor);
            SetMenuColor(buttonEditTask, new[] { lblEditTaskTitle, lblEditTaskDesc }, menuNormalColor);
            SetMenuColor(buttonSearch, new[] { lblSearchTitle, lblSearchDesc }, menuNormalColor);
            SetMenuColor(buttonStats, new[] { lblStatsTitle, lblStatsDesc }, menuNormalColor);
            SetMenuColor(buttonExit, new[] { lblExitTitle, lblExitDesc }, menuNormalColor);
        }

        private void ConfigureMenuHover(Button button, params Label[] labels)
        {
            button.FlatAppearance.MouseOverBackColor = menuHoverColor;
            button.FlatAppearance.MouseDownBackColor = menuHoverColor;

            Control[] controls = new Control[labels.Length + 1];
            controls[0] = button;

            for (int i = 0; i < labels.Length; i++)
            {
                controls[i + 1] = labels[i];
                labels[i].Cursor = Cursors.Hand;
            }

            foreach (Control control in controls)
            {
                control.MouseEnter += (sender, e) => SetMenuColor(button, labels, menuHoverColor);
                control.MouseLeave += (sender, e) =>
                {
                    BeginInvoke(() =>
                    {
                        if (!IsMouseOverAny(controls))
                        {
                            SetMenuColor(button, labels, menuNormalColor);
                        }
                    });
                };
            }
        }

        private static void SetMenuColor(Button button, Label[] labels, Color color)
        {
            button.BackColor = color;
            foreach (Label label in labels)
            {
                label.BackColor = color;
            }
        }

        private static bool IsMouseOverAny(Control[] controls)
        {
            Point mousePosition = Cursor.Position;

            foreach (Control control in controls)
            {
                Rectangle bounds = new Rectangle(control.PointToScreen(Point.Empty), control.Size);
                if (bounds.Contains(mousePosition))
                {
                    return true;
                }
            }

            return false;
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            ResetMenuColors();
            using (var form = new FormAddExpense())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadDashboard();
                }
            }
        }

        private void buttonTaskList_Click(object sender, EventArgs e)
        {
            ResetMenuColors();
            MessageBox.Show("지출 내역/검색 화면 연결 예정");
        }

        private void buttonEditTask_Click(object sender, EventArgs e)
        {
            ResetMenuColors();
            MessageBox.Show("예산 관리 화면 연결 예정");
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            ResetMenuColors();
            MessageBox.Show("고정지출 관리 화면 연결 예정");
        }

        private void buttonStats_Click(object sender, EventArgs e)
        {
            ResetMenuColors();
            using (var form = new FormStats())
            {
                form.ShowDialog(this);
            }
            LoadDashboard();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            ResetMenuColors();
            Application.Exit();
        }
    }
}
