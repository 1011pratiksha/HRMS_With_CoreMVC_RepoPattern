using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class EmployeeDeductions
    {
        [Key]
        public int EmployeeDeductionId { get; set; }

        [ForeignKey("EmployeeSalaries")]
        public int SalaryId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("Deduction")]
        public int DeductionId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DeductionAmount { get; set; }

        // Navigation properties
        public virtual EmployeeSalaries EmployeeSalaries { get; set; }
        public virtual Deduction Deduction { get; set; }
    }
}
