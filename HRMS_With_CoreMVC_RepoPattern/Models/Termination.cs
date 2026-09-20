using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class Termination
    {
        [Key]
        public int TerminationId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public string TerminationType { get; set; }

        public DateTime NoticeDate { get; set; }

        public DateTime ResignDate { get; set; }

        public string Reason { get; set; }

        public User? User { get; set; }
    }
}