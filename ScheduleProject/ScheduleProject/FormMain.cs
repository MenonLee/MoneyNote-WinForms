namespace ScheduleProject
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            lblToday.Text = "오늘 날짜: " + DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            MessageBox.Show("일정 등록 화면 연결 예정");
        }

        private void buttonTaskList_Click(object sender, EventArgs e)
        {
            MessageBox.Show("일정 목록 화면 연결 예정");
        }

        private void buttonEditTask_Click(object sender, EventArgs e)
        {
            MessageBox.Show("일정 관리 화면 연결 예정");
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("검색 화면 연결 예정");
        }

        private void buttonStats_Click(object sender, EventArgs e)
        {
            MessageBox.Show("통계 화면 연결 예정");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
