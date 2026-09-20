using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Data;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class TerminationController : Controller
    {
        private readonly ITerminationRepository terminationRepository;
        private readonly ApplicationDbContext context;

        public TerminationController(ITerminationRepository terminationRepository, ApplicationDbContext context)
        {
            this.terminationRepository = terminationRepository;
            this.context = context;
        }

        public async Task<IActionResult> Index(string? dateFilter, string? sortType)
        {
            List<Termination> li = await terminationRepository.GetTerminations();
            DateTime today = DateTime.Today;

            if (dateFilter == "Today")
                li = li.Where(x => x.NoticeDate.Date == today).ToList();
            else if (dateFilter == "LastWeek")
                li = li.Where(x => x.NoticeDate.Date >= today.AddDays(-7) && x.NoticeDate.Date <= today).ToList();
            else if (dateFilter == "LastMonth")
                li = li.Where(x => x.NoticeDate.Date >= today.AddMonths(-1) && x.NoticeDate.Date <= today).ToList();
            else if (dateFilter == "LastYear")
                li = li.Where(x => x.NoticeDate.Date >= today.AddYears(-1) && x.NoticeDate.Date <= today).ToList();

            if (sortType == "Ascending")
                li = li.OrderBy(x => x.NoticeDate).ToList();
            else if (sortType == "Descending")
                li = li.OrderByDescending(x => x.NoticeDate).ToList();

            ViewBag.DateFilter = dateFilter;
            ViewBag.SortType = sortType;
            ViewBag.Users = await context.User.ToListAsync();
            ViewBag.TerminationTypes = await context.Termination.Where(x => x.TerminationType != null).Select(x => x.TerminationType).Distinct().ToListAsync();

            return View("Termination", li);
        }

        [HttpGet]
        public async Task<IActionResult> AddTermination()
        {
            ViewBag.Users = await context.User.ToListAsync();
            ViewBag.TerminationTypes = await context.Termination.Where(x => x.TerminationType != null).Select(x => x.TerminationType).Distinct().ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTermination(Termination t)
        {
            if (ModelState.IsValid)
            {
                var user = await context.User.FindAsync(t.UserId);

                if (user != null)
                {
                    string msg = await terminationRepository.AddTermination(t);
                    TempData["msg"] = msg;
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Users = await context.User.ToListAsync();
            ViewBag.TerminationTypes = await context.Termination.Where(x => x.TerminationType != null).Select(x => x.TerminationType).Distinct().ToListAsync();
            return View(t);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTermination(int id)
        {
            string msg = await terminationRepository.DeleteTermination(id);
            TempData["msg"] = msg;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditTermination(int id)
        {
            Termination? t = await terminationRepository.GetTerminationById(id);

            if (t == null)
                return NotFound();

            ViewBag.Users = await context.User.ToListAsync();
            ViewBag.TerminationTypes = await context.Termination.Where(x => x.TerminationType != null).Select(x => x.TerminationType).Distinct().ToListAsync();

            return View(t);
        }

        [HttpPost]
        public async Task<IActionResult> EditTermination(Termination t)
        {
            if (ModelState.IsValid)
            {
                string msg = await terminationRepository.UpdateTermination(t);
                TempData["msg"] = msg;
                return RedirectToAction("Index");
            }

            ViewBag.Users = await context.User.ToListAsync();
            ViewBag.TerminationTypes = await context.Termination.Where(x => x.TerminationType != null).Select(x => x.TerminationType).Distinct().ToListAsync();

            return View(t);
        }
    }
}