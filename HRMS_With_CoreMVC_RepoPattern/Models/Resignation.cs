using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class Resignation
    {
        [Key]
        public int ResignationId { get; set; }
        public int UserID { get; set; }  
        public int DepartmentId { get; set; }  
        public DateTime NoticeDate { get; set; }
        public DateTime ResignDate { get; set; }
        public string Reason { get; set; }

        [ForeignKey("UserID")]
        public  User User { get; set; }

        [ForeignKey("DepartmentId")]
        public  Department Department { get; set; }
      
    }
}
