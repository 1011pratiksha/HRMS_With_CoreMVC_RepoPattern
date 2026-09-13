using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class EventModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Write Title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Select Any Date.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [ForeignKey("EventType")]
        public int EventTypeId { get; set; }
        public EventTypes EventType { get; set; }

        [Required(ErrorMessage = "Must be Select Status.")]
        public string Status { get; set; }
    }
}
