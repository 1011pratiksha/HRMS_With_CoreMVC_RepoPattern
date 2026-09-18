using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingRepository _service;
        public TrainingController(ITrainingRepository service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var t = await _service.FetchAll();

            ViewBag.Trainer = await _service.FetchAllTrainers();
            ViewBag.TrainingType = await _service.FetchAllTrainingTypes();
            ViewBag.User = await _service.FetchAllUsers();

            return View(t);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Training t)
        {
            string username = HttpContext.Session.GetString("DisplayName") ?? "System";
            string mess = await _service.Add(t, username);
            TempData["Message"] = mess;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Training t)
        {
            string mess = await _service.Update(t);
            TempData["Message"] = mess;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            string mess = await _service.Delete(id);
            TempData["Message"] = mess;
            return RedirectToAction("Index");
        }
    }
}