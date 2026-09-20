
using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class EventTypeService : IEventTypeService
    {
        private readonly ApplicationDbContext data;

        public EventTypeService(ApplicationDbContext context)
        {
            data = context;
        }

        public async Task AddMasterEvent(EventTypes masterEvent)
        {
            data.EventTypes.Add(masterEvent);

            await data.SaveChangesAsync();
        }

        public async Task<List<EventTypes>> GetMasterEvents()
        {
            var masterData = await data.EventTypes.ToListAsync();

            return masterData;
        }

        public async Task RemoveMasterEvent(int id)
        {
            var getEvent = await data.EventTypes.FindAsync(id);

            if (getEvent != null)
            {
                data.EventTypes.Remove(getEvent);

                await data.SaveChangesAsync();
            }
        }
    }
}
