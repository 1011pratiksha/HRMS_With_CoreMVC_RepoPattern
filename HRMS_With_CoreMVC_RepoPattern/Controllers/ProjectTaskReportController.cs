using HRMS_With_CoreMVC_RepoPattern.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class ProjectTaskReportController : Controller
    {
        private readonly ITaskReportRepository _taskReportRepository;

        public ProjectTaskReportController(ITaskReportRepository taskReportRepository)
        {
            _taskReportRepository = taskReportRepository;
        }

        public async Task<IActionResult> TaskReport(string? priorityType, string? statusType, string? sortType)
        {
            var reports = (await _taskReportRepository.GetTaskReportsAsync()).ToList();

            ViewBag.TotalTasks = reports.Count;
            ViewBag.CompletedTasks = reports.Count(x => x.Status == "Completed");
            ViewBag.OnHoldTasks = reports.Count(x => x.Status == "On Hold");
            ViewBag.OverdueTasks = reports.Count(x => x.Deadline.Date < DateTime.Today && x.Status != "Completed");

            ViewBag.CompletedCount = reports.Count(x => x.Status == "Completed");
            ViewBag.PendingCount = reports.Count(x => x.Status == "Pending");
            ViewBag.InProgressCount = reports.Count(x => x.Status == "In Progress");
            ViewBag.OnHoldCount = reports.Count(x => x.Status == "On Hold");

            ViewBag.priorityType = priorityType;
            ViewBag.statusType = statusType;
            ViewBag.sortType = sortType;

            if (!string.IsNullOrEmpty(priorityType))
                reports = reports.Where(x => x.Priority == priorityType).ToList();

            if (!string.IsNullOrEmpty(statusType))
                reports = reports.Where(x => x.Status == statusType).ToList();

            if (sortType == "Ascending")
                reports = reports.OrderBy(x => x.Deadline).ToList();
            else if (sortType == "Descending")
                reports = reports.OrderByDescending(x => x.Deadline).ToList();

            return View(reports);
        }
    }
}