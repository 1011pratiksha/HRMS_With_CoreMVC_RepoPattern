
using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IEventTypeService
    {
        Task AddMasterEvent(EventTypes masterEvent);
        Task<List<EventTypes>> GetMasterEvents();
        Task RemoveMasterEvent(int id);
    }
}

