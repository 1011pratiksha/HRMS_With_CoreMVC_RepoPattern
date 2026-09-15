using HRMS_With_CoreMVC_RepoPattern.Models;
using System.ComponentModel.DataAnnotations;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class Projects
    {
        [Key]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Project Name is required.")]
        [StringLength(255, ErrorMessage = "Project Name cannot exceed 255 characters.")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Client Name is required.")]
        [StringLength(255, ErrorMessage = "Client Name cannot exceed 255 characters.")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Priority is required.")]
        [StringLength(50, ErrorMessage = "Priority cannot exceed 50 characters.")]
        public string Priority { get; set; }

        [Required(ErrorMessage = "Project Value is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Project Value must be greater than or equal to 0.")]
        public double ProjectValue { get; set; }

        [Required(ErrorMessage = "Price Type is required.")]
        [StringLength(50, ErrorMessage = "Price Type cannot exceed 50 characters.")]
        public string PriceType { get; set; }

        [StringLength(255, ErrorMessage = "File Path cannot exceed 255 characters.")]
        public string FilePath { get; set; }

        [StringLength(255, ErrorMessage = "Logo Path cannot exceed 255 characters.")]
        public string LogoPath { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Manager is Required.")]
        public string ManagerName { get; set; }

        public List<User> Users { get; set; }

        public List<Tasks> Task { get; set; }

        public List<TaskBoards> TaskBoard { get; set; }
    }
}