namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class LeaveReport
    {
         public int LeaveRequestId { get; set; }

        public string ProfilePicture { get; set; }

        public string UserName { get; set; }

        public string LeaveType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }

        public int NumberOfDays { get; set; }

        public string Reason { get; set; }

        public string ApprovedBy { get; set; }

        public string StatusHistory { get; set; }
    }
}
