using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class ProjectReportController : Controller
    {
        IProjectRepository s;

    

    public ProjectReportController(IProjectRepository s) {

            this.s = s;
}
        public async Task<IActionResult> GetAllProjectsReports(string? priorityType, string? statusType, string? sortType)
        {
            var allprojects = await s.fetchAllProjects();
            var onholdprojects = await s.fetchOnHoldProjects();
            var overdueprojects = await s.fetchOverdueProjects();
            var projectreports = await s.fetchProjectReports();

            if (!string.IsNullOrEmpty(priorityType) || !string.IsNullOrEmpty(statusType) || !string.IsNullOrEmpty(sortType))
            {
                projectreports = await s.sortProjectReports(priorityType, statusType, sortType);
            }
            ViewBag.allprojects = allprojects;
            ViewBag.onholdprojects = onholdprojects;
            ViewBag.overdueprojects = overdueprojects;
            return View(projectreports);
        }
    }
}


