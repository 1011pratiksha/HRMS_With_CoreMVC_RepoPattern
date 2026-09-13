using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class Training
    {
        [Key]
        public int TrainingId { get; set; }

        // Foreign key to Trainer table
        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }   // Navigation property

        // Foreign key to TrainingType table
        [ForeignKey("TrainingType")]
        public int TrainingTypeId { get; set; }
        public TrainingType TrainingType { get; set; }   // Navigation property

        // Foreign key to User table (the employee attending the training)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }   // Navigation property

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TrainingCost { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedBy { get; set; }
    }
}
