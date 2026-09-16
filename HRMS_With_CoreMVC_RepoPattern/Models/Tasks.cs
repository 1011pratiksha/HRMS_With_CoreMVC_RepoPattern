using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class Tasks
    {

        [Key]
        public int TaskId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Projects Project { get; set; }


        [Required]
        public string Status { get; set; }


        [Required]
        public string Priority { get; set; }


        [StringLength(1000)]
        public string Description { get; set; }

        public string FilePath { get; set; }

        public List<TaskMembers> Taskmember { get; set; }
        public List<TaskBoards> TaskBoard { get; set; }
    }
}
