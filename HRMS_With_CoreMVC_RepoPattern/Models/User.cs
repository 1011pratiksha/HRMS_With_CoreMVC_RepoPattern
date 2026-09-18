using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        //For signup this many fiels only required
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }


        // not manadtry to fill during sigup 
        [ForeignKey("Role")]
        public int? RoleId { get; set; }
        public Role? Role { get; set; }


        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }


        [ForeignKey("Designation")]
        public int? DesignationId { get; set; }
        public Designation? Designation { get; set; }


        [DataType(DataType.Date)]
        public DateTime? DateOfJoining { get; set; }

        public string? Status { get; set; }


        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? Address { get; set; }

        public string? AboutEmployee { get; set; }

        public string? ProfilePicture { get; set; }

        public string? ReportingManager { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }


        // Navigation properties
        public ICollection<TaskMembers> TaskMembers { get; set; } = new List<TaskMembers>();

        public List<Timesheet> Timesheets { get; set; } = new List<Timesheet>();

        public List<LeaveBalance> LeaveBalances { get; set; } = new List<LeaveBalance>();

        public List<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

        public ICollection<FileUpload> FileUploads { get; set; } = new List<FileUpload>();

        public ICollection<Projects> Projects { get; set; } = new List<Projects>();
    }
}