using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class TimesheetController : Controller
    {
        private readonly ITimesheetRepository timesheetService;

        public TimesheetController(ITimesheetRepository timesheetService)
        {
            this.timesheetService = timesheetService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            int userId = 6;
            var timesheets = timesheetService.GetEmployeeTimesheets(userId);
            return View("~/Views/Timesheet/Timesheet.cshtml", timesheets);
        }

        [HttpPost]
        public IActionResult AddTimesheet(Timesheet timesheet)
        {
            timesheet.UserId = 6;
            timesheet.Status = "Pending";
            timesheet.CreatedBy = "Employee";
            timesheet.CreatedAt = DateTime.UtcNow;
            timesheetService.AddTimesheet(timesheet);
            TempData["success"] = "Timesheet submitted successfully.";
            return RedirectToAction("Index");
        }
    }
}