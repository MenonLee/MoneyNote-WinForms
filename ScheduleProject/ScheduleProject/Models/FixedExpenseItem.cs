using System;

namespace ScheduleProject.Models
{
    public class FixedExpenseItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int Amount { get; set; }
        public string Category { get; set; } = "";
        public string PaymentMethod { get; set; } = "";
        public int DayOfMonth { get; set; } // 매월 며칠에 발생하는지 (1~31)
        public string Memo { get; set; } = "";
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
    }
}
