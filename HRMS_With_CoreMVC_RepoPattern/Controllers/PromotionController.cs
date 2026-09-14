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

        public IActionResult Index()
        {
            var p = _service.FetchGetAll();

            ViewBag.User = _service.FetchAllUsers();
            ViewBag.Designation = _service.FetchAllDesignations();

            return View(p);
        }

        [HttpPost]
        public IActionResult Add(Promotion model)
        {
            string message = _service.Add(model);
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Promotion model)
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
