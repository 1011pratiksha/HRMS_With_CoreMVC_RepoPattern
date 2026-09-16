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

        public void DeleteEvent(int id)
        {
            var findEvent = data.Events.Find(id);

            if (findEvent != null)
            {
                data.Events.Remove(findEvent);
                data.SaveChanges();

            }
        }
        public List<EventModel> GetEvent()
        {
            return data.Events.Include(x => x.EventType).ToList();
        }

        public List<EventTypes> GetEventTypes()
        {
            return data.EventTypes.ToList();
        }

        public void UpdateEvent(EventModel model)
        {
            var oldData = data.Events.Find(model.Id);

            if (oldData != null)
            {
                oldData.Title = model.Title;
                oldData.Date = model.Date;
                oldData.Status = model.Status;
                oldData.EventTypeId = model.EventTypeId;
            }

            data.SaveChanges();
        }
    }
}
