using System.Drawing.Drawing2D;
using ScheduleProject.Data;

namespace ScheduleProject
{
    public partial class FormStats : Form
    {
        private Dictionary<string, int> categoryStats = new();
        private List<MonthlyGraphItem> monthlyStats = new();

        public FormStats()
        {
            InitializeComponent();
            SetupGraphView();
            LoadStats();
        }

        private void SetupGraphView()
        {
            lblTitle.Text = "지출 통계";
            lblSubtitle.Text = "카테고리와 월별 지출 흐름을 그래프로 확인합니다.";
            lblTotalCountCaption.Text = "전체 지출 건수";
            lblTotalAmountCaption.Text = "총 지출 금액";
            lblMonthlyAmountCaption.Text = "이번 달 지출";
            lblAverageAmountCaption.Text = "평균 지출";
            lblCategoryTitle.Text = "소비 그래프";
            buttonRefresh.Text = "새로고침";
            buttonClose.Text = "닫기";

            lblTitle.AutoSize = false;
            lblTitle.Location = new Point(44, 28);
            lblTitle.Size = new Size(260, 60);
            lblSubtitle.AutoSize = false;
            lblSubtitle.Location = new Point(47, 74);
            lblSubtitle.Size = new Size(620, 34);
            lblCategoryTitle.Visible = false;
            dgvCategory.Visible = false;
            panelCategory.Paint += panelCategory_Paint;
        }

        private void LoadStats()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            lblTotalCountValue.Text = DatabaseHelper.GetTotalExpenseCount().ToString("N0") + "건";
            lblTotalAmountValue.Text = FormatCurrency(DatabaseHelper.GetTotalExpenseAmount());
            lblMonthlyAmountValue.Text = FormatCurrency(DatabaseHelper.GetMonthlyExpenseAmount(year, month));
            lblAverageAmountValue.Text = FormatCurrency(DatabaseHelper.GetAverageExpenseAmount());

            categoryStats = DatabaseHelper.GetCategoryExpenseSummary();
            monthlyStats = BuildMonthlyStats();
            panelCategory.Invalidate();
        }

        private static List<MonthlyGraphItem> BuildMonthlyStats()
        {
            var items = new List<MonthlyGraphItem>();
            DateTime currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            for (int i = 5; i >= 0; i--)
            {
                DateTime month = currentMonth.AddMonths(-i);
                items.Add(new MonthlyGraphItem(
                    month.ToString("MM월"),
                    DatabaseHelper.GetMonthlyExpenseAmount(month.Year, month.Month)
                ));
            }

            return items;
        }

        private void panelCategory_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using var titleFont = new Font("맑은 고딕", 10F, FontStyle.Bold);
            using var labelFont = new Font("맑은 고딕", 8.5F, FontStyle.Regular);
            using var valueFont = new Font("맑은 고딕", 8F, FontStyle.Regular);
            using var axisPen = new Pen(Color.FromArgb(226, 232, 240), 1);
            using var textBrush = new SolidBrush(Color.FromArgb(30, 41, 59));
            using var mutedBrush = new SolidBrush(Color.FromArgb(100, 116, 139));

            int dividerX = panelCategory.ClientSize.Width / 2;
            var categoryBounds = new Rectangle(24, 62, dividerX - 52, panelCategory.ClientSize.Height - 100);
            var monthlyBounds = new Rectangle(dividerX + 34, 62, panelCategory.ClientSize.Width - dividerX - 66, panelCategory.ClientSize.Height - 100);

            e.Graphics.DrawString("카테고리별 지출", titleFont, textBrush, categoryBounds.X, 18);
            e.Graphics.DrawString("최근 6개월 지출", titleFont, textBrush, monthlyBounds.X, 18);
            e.Graphics.DrawLine(axisPen, dividerX, 58, dividerX, panelCategory.ClientSize.Height - 26);

            DrawCategoryBars(e.Graphics, categoryBounds, labelFont, valueFont, textBrush, mutedBrush);
            DrawMonthlyBars(e.Graphics, monthlyBounds, labelFont, valueFont, textBrush, mutedBrush, axisPen);
        }

        private void DrawCategoryBars(
            Graphics graphics,
            Rectangle bounds,
            Font labelFont,
            Font valueFont,
            Brush textBrush,
            Brush mutedBrush)
        {
            var items = categoryStats
                .OrderByDescending(item => item.Value)
                .Take(6)
                .ToList();

            if (items.Count == 0)
            {
                DrawEmptyMessage(graphics, bounds, "표시할 카테고리 지출이 없습니다.", mutedBrush);
                return;
            }

            int maxAmount = Math.Max(1, items.Max(item => item.Value));
            int rowHeight = 42;
            int barX = bounds.X + 98;
            int barMaxWidth = bounds.Width - 165;
            Color[] colors =
            {
                Color.FromArgb(37, 99, 235),
                Color.FromArgb(234, 88, 12),
                Color.FromArgb(5, 150, 105),
                Color.FromArgb(124, 58, 237),
                Color.FromArgb(15, 118, 110),
                Color.FromArgb(148, 163, 184)
            };

            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                int y = bounds.Y + i * rowHeight;
                int barWidth = Math.Max(8, (int)Math.Round(barMaxWidth * item.Value / (double)maxAmount));
                var barBounds = new Rectangle(barX, y + 15, barWidth, 13);

                graphics.DrawString(item.Key, labelFont, textBrush, bounds.X, y + 9);
                using var barBrush = new SolidBrush(colors[i % colors.Length]);
                graphics.FillRectangle(barBrush, barBounds);
                graphics.DrawString(FormatCurrency(item.Value), valueFont, mutedBrush, barX + barMaxWidth + 8, y + 8);
            }
        }

        private void DrawMonthlyBars(
            Graphics graphics,
            Rectangle bounds,
            Font labelFont,
            Font valueFont,
            Brush textBrush,
            Brush mutedBrush,
            Pen axisPen)
        {
            if (monthlyStats.Count == 0 || monthlyStats.All(item => item.Amount == 0))
            {
                DrawEmptyMessage(graphics, bounds, "최근 6개월 지출이 없습니다.", mutedBrush);
                return;
            }

            int maxAmount = Math.Max(1, monthlyStats.Max(item => item.Amount));
            int chartBottom = bounds.Bottom - 44;
            int chartTop = bounds.Top + 12;
            int chartHeight = chartBottom - chartTop;
            int barWidth = 34;
            int gap = (bounds.Width - monthlyStats.Count * barWidth) / Math.Max(1, monthlyStats.Count + 1);

            graphics.DrawLine(axisPen, bounds.X, chartBottom, bounds.Right, chartBottom);

            for (int i = 0; i < monthlyStats.Count; i++)
            {
                var item = monthlyStats[i];
                int x = bounds.X + gap + i * (barWidth + gap);
                int barHeight = item.Amount == 0 ? 2 : Math.Max(8, (int)Math.Round(chartHeight * item.Amount / (double)maxAmount));
                int y = chartBottom - barHeight;
                var barBounds = new Rectangle(x, y, barWidth, barHeight);

                using var barBrush = new SolidBrush(i == monthlyStats.Count - 1
                    ? Color.FromArgb(37, 99, 235)
                    : Color.FromArgb(148, 163, 184));
                graphics.FillRectangle(barBrush, barBounds);

                var labelBounds = new Rectangle(x - 10, chartBottom + 8, barWidth + 20, 18);
                TextRenderer.DrawText(graphics, item.Label, labelFont, labelBounds, ((SolidBrush)textBrush).Color, TextFormatFlags.HorizontalCenter);

                if (item.Amount > 0)
                {
                    var valueBounds = new Rectangle(x - 26, y - 22, barWidth + 52, 18);
                    TextRenderer.DrawText(graphics, ShortCurrency(item.Amount), valueFont, valueBounds, ((SolidBrush)mutedBrush).Color, TextFormatFlags.HorizontalCenter);
                }
            }
        }

        private static void DrawEmptyMessage(Graphics graphics, Rectangle bounds, string message, Brush brush)
        {
            using var font = new Font("맑은 고딕", 9F, FontStyle.Regular);
            var messageBounds = new Rectangle(bounds.X, bounds.Y + 80, bounds.Width, 30);
            TextRenderer.DrawText(
                graphics,
                message,
                font,
                messageBounds,
                ((SolidBrush)brush).Color,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private static string FormatCurrency(int amount)
        {
            return amount.ToString("N0") + "원";
        }

        private static string ShortCurrency(int amount)
        {
            return amount >= 10000
                ? (amount / 10000.0).ToString("0.#") + "만"
                : amount.ToString("N0");
        }

        private void buttonRefresh_Click(object sender, EventArgs e) => LoadStats();

        private void buttonClose_Click(object sender, EventArgs e) => Close();

        private readonly record struct MonthlyGraphItem(string Label, int Amount);
    }
}
