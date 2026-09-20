using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class LeaveBalance
    {
        [Key]
        public int LeaveBalanceId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("DepartmentLeaves")]
        public int DepartmentLeavesId { get; set; }
        public DepartmentLeaves DepartmentLeaves { get; set; }
        [ForeignKey("MasterLeaveType")]
        public int LeaveTypeId { get; set; }
        public MasterLeaveType MasterLeaveType { get; set; }
        public int TotalLeaves { get; set; }
        public int UsedLeaves { get; set; }
        [NotMapped]
        public int RemainingLeaves => TotalLeaves - UsedLeaves;
    }
}