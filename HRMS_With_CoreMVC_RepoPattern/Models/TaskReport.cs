namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class TaskReport
    {
         public int TaskId { get; set; }
        public string Title { get; set; }
        public string ProjectName { get; set; }
        public DateTime Deadline { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}
