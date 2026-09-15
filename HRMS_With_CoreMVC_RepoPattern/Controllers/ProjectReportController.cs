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
        public async Task<IActionResult> GetAllProjectsReports(
     string? priorityType,
     string? statusType,
     string? sortType)
        {
            var allprojects = await s.fetchAllProjects();
            var onholdprojects = await s.fetchOnHoldProjects();
            var overdueprojects = await s.fetchOverdueProjects();

            var allProjectReports = await s.fetchProjectReports();

            var activeProjects = allProjectReports
                .Count(x => x.Status == "Active");

            var inactiveProjects = allProjectReports
                .Count(x => x.Status == "Inactive");

            var highProjects = allProjectReports
                .Count(x => x.Priority == "High");

            var mediumProjects = allProjectReports
                .Count(x => x.Priority == "Medium");

            var lowProjects = allProjectReports
                .Count(x => x.Priority == "Low");


            var projectreports = allProjectReports;

            if (!string.IsNullOrEmpty(priorityType) ||
                !string.IsNullOrEmpty(statusType) ||
                !string.IsNullOrEmpty(sortType))
            {
                projectreports = await s.sortProjectReports(
                    priorityType,
                    statusType,
                    sortType);
            }


            ViewBag.allprojects = allprojects;
            ViewBag.onholdprojects = onholdprojects;
            ViewBag.overdueprojects = overdueprojects;

            ViewBag.activeProjects = activeProjects;
            ViewBag.inactiveProjects = inactiveProjects;

            ViewBag.highProjects = highProjects;
            ViewBag.mediumProjects = mediumProjects;
            ViewBag.lowProjects = lowProjects;

            return View(projectreports);
        } }
    }