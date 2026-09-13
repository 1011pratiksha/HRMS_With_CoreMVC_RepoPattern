namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class PayslipReport
    {
         public int PayslipId { get; set; }
        public string UserName { get; set; }
        public string Designation { get; set; }
        public string ProfilePicture { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaidMonth { get; set; }
        public int PaidYear { get; set; }
    }
}
