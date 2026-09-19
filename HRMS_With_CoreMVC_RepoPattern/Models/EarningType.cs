using System.ComponentModel.DataAnnotations;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class EarningType
    {
        [Key]
        public int EarntypeId { get; set; }
        public string EarningName { get; set; }
        public List<Earning> Earnings { get; set; }
    }
}
