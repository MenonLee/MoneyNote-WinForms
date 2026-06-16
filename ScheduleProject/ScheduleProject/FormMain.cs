using System.Drawing;

namespace ScheduleProject
{
    public partial class FormMain : Form
    {
        private readonly Color menuNormalColor = Color.White;
        private readonly Color menuHoverColor = Color.FromArgb(226, 232, 240);

        public FormMain()
        {
            InitializeComponent();

            lblToday.Text = "오늘 날짜: " + DateTime.Now.ToString("yyyy-MM-dd");
            InitializeMenuHoverEffects();
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
                form.ShowDialog(this);
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
            using (var form = new ScheduleProject.Forms.FormFixedExpense())
            {
                form.ShowDialog(this);
            }
        }

        private void buttonStats_Click(object sender, EventArgs e)
        {
            ResetMenuColors();
            MessageBox.Show("소비 분석 화면 연결 예정");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            ResetMenuColors();
            Application.Exit();
        }
    }
}
