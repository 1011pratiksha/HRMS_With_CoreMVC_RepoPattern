using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class EventTypeService : IEventTypeService
    {
        private readonly ApplicationDbContext data;

        public EventTypeService(ApplicationDbContext context)
        {
            data = context;
        }


        public void AddMasterEvent(EventTypes masterEvent)
        {
            data.EventTypes.Add(masterEvent);
            data.SaveChanges();
        }

        public List<EventTypes> GetMasterEvents()
        {
            var masterData = data.EventTypes.ToList();
            return masterData;

        }

        public void RemoveMasterEvent(int id)
        {
            var getEvent = data.EventTypes.Find(id);

            if (getEvent != null)
            {
                data.EventTypes.Remove(getEvent);
                data.SaveChanges();

            }
        }
    }
}
