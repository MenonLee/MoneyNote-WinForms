using ScheduleProject.Data;

namespace ScheduleProject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            DatabaseHelper.InitializeDatabase();
            DatabaseHelper.ProcessMonthlyFixedExpenses(); // 고정지출 자동화 실행
            Application.Run(new FormMain());
        }
    }
}
