
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly IEventTypeService service;

        public EventTypeController(IEventTypeService serviceData)
        {
            service = serviceData;
        }

        public async Task<IActionResult> Index()
        {
            var master = await service.GetMasterEvents();

            return View(master);
        }

        [HttpPost]
        public async Task<IActionResult> AddMaster(EventTypes masterEvent)
        {
            await service.AddMasterEvent(masterEvent);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteEvent(int id)
        {
            await service.RemoveMasterEvent(id);

            return RedirectToAction("Index");
        }
    }
}
