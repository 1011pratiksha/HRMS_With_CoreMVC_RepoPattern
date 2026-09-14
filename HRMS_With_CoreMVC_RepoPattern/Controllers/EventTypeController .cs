using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly IEventTypeService service;
        public EventTypeController(IEventTypeService serviceData) { 
            service = serviceData;
        }
        public IActionResult Index()
        {
            var master = service.GetMasterEvents();

            return View(master);
        }

        [HttpPost]
        public IActionResult AddMaster(EventTypes masterEvent)
        {
            service.AddMasterEvent(masterEvent);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteEvent(int id)
        {
            service.RemoveMasterEvent(id);

            return RedirectToAction("Index");
        }
    }
}
