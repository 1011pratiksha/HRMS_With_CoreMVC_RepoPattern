
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

        public async Task AddEvent(EventModel model)
        {
            data.Events.Add(model);

            await data.SaveChangesAsync();
        }

        public async Task DeleteEvent(int id)
        {
            var findEvent = await data.Events.FindAsync(id);

            if (findEvent != null)
            {
                data.Events.Remove(findEvent);

                await data.SaveChangesAsync();
            }
        }

        public async Task<List<EventModel>> GetEvent()
        {
            return await data.Events.Include(x => x.EventType).ToListAsync();
        }

        public async Task<List<EventTypes>> GetEventTypes()
        {
            return await data.EventTypes.ToListAsync();
        }

        public async Task UpdateEvent(EventModel model)
        {
            var oldData = await data.Events.FindAsync(model.Id);

            if (oldData != null)
            {
                oldData.Title = model.Title;
                oldData.Date = model.Date;
                oldData.Status = model.Status;
                oldData.EventTypeId = model.EventTypeId;

                await data.SaveChangesAsync();
            }
        }
    }
}
