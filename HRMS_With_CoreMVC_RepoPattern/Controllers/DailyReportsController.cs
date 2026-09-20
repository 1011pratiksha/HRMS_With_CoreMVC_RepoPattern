using HRMS_With_CoreMVC_RepoPattern.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class DailyReportsController : Controller
    {
        private readonly IDailyReportRepository _dailyReportRepository;

        public DailyReportsController(IDailyReportRepository dailyReportRepository)
        {
            _dailyReportRepository = dailyReportRepository;
        }

        public async Task<IActionResult> DailyReport()
        {
            var reports = await _dailyReportRepository.GetDailyReportsAsync();

            ViewBag.TotalPresent = reports.Count(x => x.Status == "Present");
            ViewBag.TotalAbsent = reports.Count(x => x.Status == "Absent");
            ViewBag.CompletedTasks = reports.Count(x => x.Status == "Completed");
            ViewBag.PendingTasks = reports.Count(x => x.Status == "Pending");
            ViewBag.PresentCount = reports.Count(x => x.Status == "Present");
            ViewBag.AbsentCount = reports.Count(x => x.Status == "Absent");

            return View(reports);
        }
    }
}