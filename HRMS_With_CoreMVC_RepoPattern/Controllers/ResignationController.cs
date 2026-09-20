using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class ResignationController : Controller
    {
        private readonly IResignationRepository resignationRepository;
        private readonly ApplicationDbContext context;

        public ResignationController(IResignationRepository resignationRepository, ApplicationDbContext context)
        {
            this.resignationRepository = resignationRepository;
            this.context = context;
        }

        public async Task<IActionResult> Index(string? dateFilter, string? sortType)
        {
            List<Resignation> li = await resignationRepository.GetResignations();
            DateTime today = DateTime.Today;

            switch (dateFilter)
            {
                case "Today":
                    li = li.Where(x => x.NoticeDate.Date == today).ToList();
                    break;
                case "LastWeek":
                    li = li.Where(x => x.NoticeDate.Date >= today.AddDays(-7) && x.NoticeDate.Date <= today).ToList();
                    break;
                case "LastMonth":
                    li = li.Where(x => x.NoticeDate.Date >= today.AddMonths(-1) && x.NoticeDate.Date <= today).ToList();
                    break;
                case "LastYear":
                    li = li.Where(x => x.NoticeDate.Date >= today.AddYears(-1) && x.NoticeDate.Date <= today).ToList();
                    break;
            }

            if (sortType == "Ascending")
                li = li.OrderBy(x => x.NoticeDate).ToList();
            else if (sortType == "Descending")
                li = li.OrderByDescending(x => x.NoticeDate).ToList();

            ViewBag.Users = await context.User.Include(x => x.Department).ToListAsync();
            ViewBag.DateFilter = dateFilter;
            ViewBag.SortType = sortType;

            return View("Resignation", li);
        }

        [HttpPost]
        public async Task<IActionResult> AddResignation(Resignation r)
        {
            if (ModelState.IsValid)
            {
                var user = await context.User.Include(x => x.Department).FirstOrDefaultAsync(x => x.UserId == r.UserId);

                if (user != null)
                {
                    r.DepartmentId = user.DepartmentId ?? 0;
                    string msg = await resignationRepository.AddResignation(r);
                    TempData["msg"] = msg;
                    return RedirectToAction("Index");
                }
            }

            TempData["msg"] = "Please select a valid employee.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditResignation(Resignation r)
        {
            if (ModelState.IsValid)
            {
                var user = await context.User.Include(x => x.Department).FirstOrDefaultAsync(x => x.UserId == r.UserId);

                if (user != null)
                {
                    r.DepartmentId = user.DepartmentId ?? 0;
                    string msg = await resignationRepository.UpdateResignation(r);
                    TempData["msg"] = msg;
                    return RedirectToAction("Index");
                }
            }

            TempData["msg"] = "Please select a valid employee.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteResignation(int id)
        {
            string msg = await resignationRepository.DeleteResignation(id);
            TempData["msg"] = msg;
            return RedirectToAction("Index");
        }
    }
}