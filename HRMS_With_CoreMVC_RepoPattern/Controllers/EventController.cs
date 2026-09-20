
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

        public async Task<IActionResult> Index()
        {
            ViewBag.EventTypes = await service.GetEventTypes();

            var ev = await service.GetEvent();

            return View(ev);
        }

        public async Task<IActionResult> EventList()
        {
            ViewBag.EventTypes = await service.GetEventTypes();

            var ev = await service.GetEvent();

            return View(ev);
        }

        [HttpPost]
        public async Task<IActionResult> AddActualEvent(EventModel model)
        {
            await service.AddEvent(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EventDelete(int id)
        {
            await service.DeleteEvent(id);

            return RedirectToAction("EventList");
        }

        public async Task<IActionResult> updateEvent(EventModel model)
        {
            await service.UpdateEvent(model);

            return RedirectToAction("EventList");
        }
    }
}
