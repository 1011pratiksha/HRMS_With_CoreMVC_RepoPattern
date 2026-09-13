using System.ComponentModel.DataAnnotations;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class TrainingType
    {
        [Key]
        public int TrainingTypeId { get; set; }

        [Required]
        public string TrainingTypeName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
