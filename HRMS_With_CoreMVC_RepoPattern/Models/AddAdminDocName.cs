using System.ComponentModel.DataAnnotations;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class AddAdminDocName
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "DocName is required.")]

        public string DocName { get; set; }
    }
}
