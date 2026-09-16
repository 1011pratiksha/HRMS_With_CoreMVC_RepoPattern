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

        public async Task<IActionResult> Index()
        {
            var t = await _service.FetchAll();
            ViewBag.Role = await _service.FetchAllRoles();
            return View(t);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Trainer model)
        {
            string message = await _service.Add(model);
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Trainer model)
        {
            string message = await _service.Update(model);
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            string message = await _service.Delete(id);
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }
    }
}
