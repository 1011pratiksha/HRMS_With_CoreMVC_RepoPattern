using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Data;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class TerminationController : Controller
    {
        private readonly ITerminationRepository terminationRepository;
        private readonly ApplicationDbContext context;

        public TerminationController(
            ITerminationRepository terminationRepository,
            ApplicationDbContext context)
        {
            this.terminationRepository = terminationRepository;
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Termination> li = terminationRepository.GetTerminations();

            return View("Termination", li);
        }

        [HttpGet]
        public IActionResult AddTermination()
        {
            ViewBag.Users = context.User.ToList();

            ViewBag.TerminationTypes = context.Termination
                .Where(x => x.TerminationType != null)
                .Select(x => x.TerminationType)
                .Distinct()
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddTermination(Termination t)
        {
            if (ModelState.IsValid)
            {
                var user = context.User.Find(t.UserId);

                if (user != null)
                {
                    terminationRepository.AddTermination(t);

                    TempData["msg"] = "Added Successfully";

                    return RedirectToAction("Index");
                }
            }

            ViewBag.Users = context.User.ToList();

            ViewBag.TerminationTypes = context.Termination
                .Where(x => x.TerminationType != null)
                .Select(x => x.TerminationType)
                .Distinct()
                .ToList();

            return View(t);
        }

        [HttpPost]
        public IActionResult DeleteTermination(int id)
        {
            string msg = terminationRepository.DeleteTermination(id);

            TempData["msg"] = msg;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTermination(int id)
        {
            Termination t = terminationRepository.GetTerminationById(id);

            if (t == null)
            {
                return NotFound();
            }

            ViewBag.Users = context.User.ToList();

            ViewBag.TerminationTypes = context.Termination
                .Where(x => x.TerminationType != null)
                .Select(x => x.TerminationType)
                .Distinct()
                .ToList();

            return View(t);
        }

        [HttpPost]
        public IActionResult EditTermination(Termination t)
        {
            if (ModelState.IsValid)
            {
                string msg = terminationRepository.UpdateTermination(t);

                TempData["msg"] = msg;

                return RedirectToAction("Index");
            }

            ViewBag.Users = context.User.ToList();

            ViewBag.TerminationTypes = context.Termination
                .Where(x => x.TerminationType != null)
                .Select(x => x.TerminationType)
                .Distinct()
                .ToList();

            return View(t);
        }
    }
}