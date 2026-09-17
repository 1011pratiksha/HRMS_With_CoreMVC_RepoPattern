using System.ComponentModel.DataAnnotations;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string Name { get; set; }

        public int NoOfEmployee { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public List<Designation> Designations { get; set; }
            = new List<Designation>();

        public List<DepartmentLeaves> DepartmentLeaves { get; set; }
            = new List<DepartmentLeaves>();

        public List<Earning> Earnings { get; set; }
            = new List<Earning>();

        public List<Deduction> Deductions { get; set; }
            = new List<Deduction>();
    }
}