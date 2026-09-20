
namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class EmployeeGridViewModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? ProfilePicture { get; set; }

        public string? DesignationName { get; set; }

        public int TotalProjects { get; set; }

        public int CompletedTasks { get; set; }

        public int InProgressTasks { get; set; }

        public int PendingTasks { get; set; }

        public int Productivity { get; set; }

        public string? Status { get; set; }
    }
}
