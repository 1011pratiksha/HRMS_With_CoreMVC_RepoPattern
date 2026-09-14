using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IEventTypeService
    {
        public void AddMasterEvent(EventTypes masterEvent);

        List<EventTypes> GetMasterEvents();

        public void RemoveMasterEvent(int id);
    }
}
