using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

     
        public string FirstName { get; set; }

  
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [ForeignKey("Department")]

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        [ForeignKey("Designation")]

        public int? DesignationtId { get; set; }
        public Designation? Designation { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }

        public string Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }
        public string AboutEmployee { get; set; }
        public string ProfilePicture { get; set; }

        public string? ReportingManager { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public ICollection<TaskMembers> TaskMembers { get; set; }
        public List<Timesheet> Timesheets { get; set; }

        public List<LeaveBalance> LeaveBalances { get; set; }
        public List<LeaveRequest> LeaveRequests { get; set; }

        public ICollection<FileUpload> FileUploads { get; set; }

        public  ICollection<Projects> Projects { get; set; } = new List<Projects>();

        


    }
}
