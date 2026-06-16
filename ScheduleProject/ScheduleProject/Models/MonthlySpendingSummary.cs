using System.Collections.Generic;

namespace ScheduleProject.Models
{
    public class MonthlySpendingSummary
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int TotalExpenseAmount { get; set; }
        public int MonthlyBudget { get; set; }
        public int FixedExpenseAmount { get; set; }
        public Dictionary<string, int> CategorySpending { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> CategoryBudgets { get; set; } = new Dictionary<string, int>();
        public List<ExpenseItem> RecentExpenses { get; set; } = new List<ExpenseItem>();
    }
}
