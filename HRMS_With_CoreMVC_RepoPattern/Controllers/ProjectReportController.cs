using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class ProjectReportController : Controller
    {
        private readonly IProjectReportRepository s;

        public ProjectReportController(IProjectReportRepository s)
        {
            this.s = s;
        }

        public async Task<IActionResult> GetAllProjectsReports(string? priorityType, string? statusType, string? sortType)
        {
            var allprojects = await s.fetchAllProjects();
            var overdueprojects = await s.fetchOverdueProjects();
            var onholdtasks = await s.fetchOnHoldTasks();
            var inProgressTasks = await s.fetchInProgressTasks();
            var completedTasks = await s.fetchCompletedTasks();
            var projectreports = await s.fetchProjectReports();

            if (!string.IsNullOrEmpty(priorityType) || !string.IsNullOrEmpty(statusType) || !string.IsNullOrEmpty(sortType))
                projectreports = await s.sortProjectReports(priorityType, statusType, sortType);

            ViewBag.allprojects = allprojects;
            ViewBag.overdueprojects = overdueprojects;
            ViewBag.onholdtasks = onholdtasks;
            ViewBag.inProgressTasks = inProgressTasks;
            ViewBag.completedTasks = completedTasks;
            ViewBag.priorityType = priorityType;
            ViewBag.statusType = statusType;
            ViewBag.sortType = sortType;

            return View(projectreports);
        }
    }
}