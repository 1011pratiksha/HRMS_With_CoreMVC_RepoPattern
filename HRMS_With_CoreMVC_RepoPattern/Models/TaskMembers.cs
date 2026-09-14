using System.ComponentModel.DataAnnotations;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class TaskMembers
    {
        [Key]
        public int AssignedId { get; set; }

        public int TaskId { get; set; }
        public Tasks Task { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}