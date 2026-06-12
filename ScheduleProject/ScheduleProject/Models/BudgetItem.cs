using System;

namespace ScheduleProject.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string Category { get; set; } = ""; // 비어있으면 전체 예산
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
