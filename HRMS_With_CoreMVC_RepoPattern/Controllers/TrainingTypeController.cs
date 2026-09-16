using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class TrainingTypeController : Controller
    {
        private readonly ITrainingTypeRepository _service;
        public TrainingTypeController(ITrainingTypeRepository service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var t = await _service.FetchAll();
            return View(t);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TrainingType t)
        {
            string mess = await _service.Add(t);
            TempData["Message"] = mess;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(TrainingType t)
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
