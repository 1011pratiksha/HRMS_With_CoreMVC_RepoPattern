namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class AttendanceReport
    {
        public int AttendanceId { get; set; }

        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? ProfilePicture { get; set; }

        public DateTime Date { get; set; }

        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public DateTime? LunchIn { get; set; }

        public DateTime? LunchOut { get; set; }

        public string? Status { get; set; }

        public decimal WorkingHours { get; set; }

        public decimal OvertimeHours { get; set; }

        public decimal BreakHours { get; set; }

        public int Late { get; set; }

        public decimal ProductionHours { get; set; }
    }
}