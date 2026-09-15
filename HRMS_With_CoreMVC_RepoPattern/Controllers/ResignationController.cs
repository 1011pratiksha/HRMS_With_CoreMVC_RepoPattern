using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Data;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class ResignationController : Controller
    {
        private readonly IResignationRepository resignationRepository;
        private readonly ApplicationDbContext context;

        public ResignationController(
            IResignationRepository resignationRepository,
            ApplicationDbContext context)
        {
            this.resignationRepository = resignationRepository;
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Resignation> li = resignationRepository.GetResignations();
            return View("Resignation", li);
        }

        [HttpGet]
        public IActionResult AddResignation()
        {
            ViewBag.Users = context.User.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddResignation(Resignation r)
        {
            if (ModelState.IsValid)
            {
                var user = context.User.Find(r.UserId);

                if (user != null)
                {
                    r.DepartmentId = user.DepartmentId ?? 0;

                    resignationRepository.AddResignation(r);

                    TempData["msg"] = "Added Successfully";

                    return RedirectToAction("Index");
                }
            }

            ViewBag.Users = context.User.ToList();

            return View(r);
        }

        [HttpPost]
        public IActionResult DeleteResignation(int id)
        {
            string msg = resignationRepository.DeleteResignation(id);

            TempData["msg"] = msg;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditResignation(Resignation r)
        {
            if (ModelState.IsValid)
            {
                string msg = resignationRepository.UpdateResignation(r);

                TempData["msg"] = msg;

                return RedirectToAction("Index");
            }

            return View(r);
        }

        [HttpGet]
        public IActionResult EditResignation(int id)
        {
            Resignation r = resignationRepository.GetResignationById(id);

            if (r == null)
            {
                return NotFound();
            }

            return View(r);
        }
    }
}