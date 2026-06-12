using System;

namespace ScheduleProject.Models
{
    public class AiAnalysisLog
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string Summary { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
