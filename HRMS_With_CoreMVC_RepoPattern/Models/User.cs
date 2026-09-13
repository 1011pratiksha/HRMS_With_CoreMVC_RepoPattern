using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone(ErrorMessage = "Invalid Phone Number.")]
        public string PhoneNumber { get; set; }

        [ForeignKey("Role")]
        [Required(ErrorMessage = "Role is required.")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [ForeignKey("Department")]

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        [ForeignKey("Designation")]

        public int? DesignationtId { get; set; }
        public Designation? Designation { get; set; }

        [Required(ErrorMessage = "Date of Joining is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
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

<<<<<<< HEAD
        public List<Timesheet> Timesheets { get; set; }

        public List<LeaveBalance> LeaveBalances { get; set; }
        public List<LeaveRequest> LeaveRequests { get; set; }

        public ICollection<FileUpload> FileUploads { get; set; }

        public virtual ICollection<Projects> Projects { get; set; } = new List<Projects>();
=======
        public List<Projects> Projects { get; set; } 
>>>>>>> b5b404ba5f5774415438c1fd3d61918b599f7259


    }
}
