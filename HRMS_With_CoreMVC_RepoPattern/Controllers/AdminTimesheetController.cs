using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class AdminTimesheetController : Controller
    {
        private readonly ITimesheetRepository timesheetService;

        public AdminTimesheetController(ITimesheetRepository timesheetService)
        {
            this.timesheetService = timesheetService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var timesheets = timesheetService.GetAllTimesheets();
            ViewBag.Projects = timesheetService.GetProjects();
            return View("~/Views/Timesheet/AdminTimesheet.cshtml", timesheets);
        }

        [HttpPost]
        public IActionResult UpdateStatus(List<int> timesheetIds, string status)
        {
            if (timesheetIds == null || timesheetIds.Count == 0)
            {
                TempData["error"] = "Please select at least one timesheet.";
                return RedirectToAction("Index");
            }

            timesheetService.UpdateTimesheetStatus(timesheetIds, status, "Admin");
            TempData["success"] = "Timesheet status updated successfully.";
            return RedirectToAction("Index");
        }
    }
}