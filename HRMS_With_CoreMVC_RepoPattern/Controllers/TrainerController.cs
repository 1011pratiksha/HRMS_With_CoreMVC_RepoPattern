using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerRepository _service;

        public TrainerController(ITrainerRepository service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var t = _service.FetchAll();
            ViewBag.Role = _service.FetchAllRoles();
            return View(t);
        }

        [HttpPost]
        public IActionResult Add(Trainer model)
        {
            string message = _service.Add(model);
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Trainer model)
        {
            string message = _service.Update(model);
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            string message = _service.Delete(id);
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }
    }
}
