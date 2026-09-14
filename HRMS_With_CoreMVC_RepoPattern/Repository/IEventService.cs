using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IEventService
    {
        public void AddEvent(EventModel model);

        public List<EventTypes> GetEventTypes();

        public List<EventModel> GetEvent();
    }
}
