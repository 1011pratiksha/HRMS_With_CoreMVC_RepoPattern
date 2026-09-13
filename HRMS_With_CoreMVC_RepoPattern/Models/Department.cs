using System.ComponentModel.DataAnnotations;

namespace Pulse360.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
      
        public string Name { get; set; }
        public int NoOfEmployee { get; set; }
       
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public List<Designation> Designations { get; set; }

        public List<DepartmentLeaves> DepartmentLeaves { get; set; }

        public List<Earning> Earnings { get; set; }
        public List<Deduction> Deductions { get; set; }

       

    }
}
