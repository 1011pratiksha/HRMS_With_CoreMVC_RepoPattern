using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class PromotionController : Controller
    {
        private readonly IPromotionRepository _service;

        public PromotionController(IPromotionRepository service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var p = await _service.FetchGetAll();

            ViewBag.User = await _service.FetchAllUsers();
            ViewBag.Designation = await _service.FetchAllDesignations();

            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Promotion model)
        {
            string message = await _service.Add(model);
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Promotion model)
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
