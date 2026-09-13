using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class FileUploadViewModel
    {
        public int UserId { get; set; }
        public List<string> DocumentTypes { get; set; } = new List<string>();
        public List<IFormFile> Files { get; set; } = new List<IFormFile>();

        [ForeignKey("AddAdminDocName")]
        public int Id { get; set; }
        public AddAdminDocName AddEmployeeDocName { get; set; }
    }
}
