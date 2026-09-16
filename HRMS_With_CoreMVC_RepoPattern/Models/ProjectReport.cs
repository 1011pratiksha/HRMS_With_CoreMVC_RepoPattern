using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class ProjectReport
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ManagerName { get; set; }

        public DateTime EndDate { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        [NotMapped]
        public List<string> Members { get; set; } = new List<string>();
    }
}