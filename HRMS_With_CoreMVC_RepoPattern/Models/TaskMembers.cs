using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class TaskMembers
    {
        [Key]
        public int AssignedId { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public Tasks Task { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}