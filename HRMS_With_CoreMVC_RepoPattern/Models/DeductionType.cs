using System.ComponentModel.DataAnnotations;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class DeductionType
    {
        [Key]
        public int DeductionTypeId { get; set; }
        [Required]
        [StringLength(100)]
        public string DeductionsName { get; set; }
        public virtual ICollection<Deduction> Deductions { get; set; }
    }
}
