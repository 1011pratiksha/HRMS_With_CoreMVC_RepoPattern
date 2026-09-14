using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class EventService : IEventService
    {

        public readonly ApplicationDbContext data;
        public EventService(ApplicationDbContext context)
        {
            data = context;
        }

        public void AddEvent(EventModel model)
        {
            data.Events.Add(model);    
            data.SaveChanges();
        }



        public List<EventModel> GetEvent()
        {
            return data.Events.Include(x => x.EventType).ToList();
        }

        public List<EventTypes> GetEventTypes()
        {
            return data.EventTypes.ToList();
        }
    }
}
