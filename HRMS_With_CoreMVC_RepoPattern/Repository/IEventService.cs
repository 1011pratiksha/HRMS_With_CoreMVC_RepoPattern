
using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IEventService
    {
        Task AddEvent(EventModel model);

        Task<List<EventTypes>> GetEventTypes();

        Task<List<EventModel>> GetEvent();

        Task DeleteEvent(int id);

        Task UpdateEvent(EventModel model);
    }
}