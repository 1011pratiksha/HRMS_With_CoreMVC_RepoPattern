using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class ManagerTimesheetController : Controller
    {
        private readonly ITimesheetRepository timesheetService;

        public ManagerTimesheetController(ITimesheetRepository timesheetService)
        {
            this.timesheetService = timesheetService;
        }

        [HttpGet]
        public IActionResult Approval()
        {
            var timesheets = timesheetService.GetAllTimesheets();
            return View("~/Views/Timesheet/ManagerTimesheetApproval.cshtml", timesheets);
        }

        [HttpPost]
        public IActionResult UpdateStatus(List<int> timesheetIds, string status)
        {
            if (timesheetIds == null || timesheetIds.Count == 0)
            {
                TempData["error"] = "Please select at least one timesheet.";
                return RedirectToAction("Approval");
            }

            timesheetService.UpdateTimesheetStatus(timesheetIds, status);
            TempData["success"] = "Timesheet status updated successfully!";
            return RedirectToAction("Approval");
        }
    }
}