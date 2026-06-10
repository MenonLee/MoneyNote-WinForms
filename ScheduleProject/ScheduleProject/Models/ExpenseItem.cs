using System;

namespace ScheduleProject.Models
{
    public class ExpenseItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int Amount { get; set; }
        public string Category { get; set; } = "";
        public string PaymentMethod { get; set; } = "";
        public DateTime ExpenseDate { get; set; }
        public string Memo { get; set; } = "";
        public int? FixedExpenseRefId { get; set; } // 고정지출 자동 생성 출처 ID
        public DateTime CreatedAt { get; set; }
    }
}
