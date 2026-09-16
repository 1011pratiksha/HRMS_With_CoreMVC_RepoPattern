using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class EventController : Controller
    {
        public readonly IEventService service;
        public EventController(IEventService eventService) 
        {
            service = eventService;
        }
        public IActionResult Index()
        {
            ViewBag.EventTypes= service.GetEventTypes();
            var ev = service.GetEvent();

            return View(ev);
        }

        public IActionResult EventList()
        {
            ViewBag.EventTypes = service.GetEventTypes();
            var ev = service.GetEvent();

            return View(ev);
        }

        [HttpPost]
        public IActionResult AddActualEvent(EventModel model)
        {
            service.AddEvent(model);
            return RedirectToAction("Index");
        }

        public IActionResult EventDelete(int id)
        {
            service.DeleteEvent(id);
            return RedirectToAction("EventList");

        }

        public IActionResult updateEvent(EventModel model)
        {
            service.UpdateEvent(model);

            return RedirectToAction("EventList");
        }
       
    }
}
