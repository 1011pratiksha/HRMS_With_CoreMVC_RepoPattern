namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class EmployeeReport
    {
         public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfJoining { get; set; }

        public string Status { get; set; }

        public string ProfilePicture { get; set; }
    }
}
