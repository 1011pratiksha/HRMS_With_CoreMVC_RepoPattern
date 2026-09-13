using System.ComponentModel.DataAnnotations;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class EventTypes
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Event Type  Name is Required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Select Any Color.")]
        public string color { get; set; }
        public List<EventModel> Event { get; set; }
    }
}
