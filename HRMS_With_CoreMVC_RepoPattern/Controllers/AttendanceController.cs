using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceRepository attendanceService;

        public AttendanceController(IAttendanceRepository attendanceService)
        {
            this.attendanceService = attendanceService;
        }

        [HttpGet]
        public async Task<IActionResult> AdminAttendanceList(DateTime? startDate, DateTime? endDate, int? departmentId, string status, string search, string sort)
        {
            var data = await attendanceService.GetFilteredAttendance(startDate, endDate, departmentId, status, search, sort);
            var departments = await attendanceService.GetDepartments();
            var totalEmployees = await attendanceService.GetTotalEmployees();
            var today = DateTime.Today;
            var todayData = data.Where(x => x.Date.Date == today).ToList();
            ViewBag.Departments = departments;
            ViewBag.TotalEmployees = totalEmployees;
            ViewBag.Present = todayData.Count(x => x.Status == "Present");
            ViewBag.Late = todayData.Count(x => x.Status == "Late");
            ViewBag.Uninformed = todayData.Count(x => x.Status == "Uninformed");
            ViewBag.Permission = todayData.Count(x => x.Status == "Permission");
            ViewBag.Absent = todayData.Count(x => x.Status == "Absent");
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> EditAttendance(int id)
        {
            var attendance = await attendanceService.GetAttendanceById(id);
            if (attendance == null)
            {
                return NotFound();
            }
            return View(attendance);
        }

        [HttpPost]
        public async Task<IActionResult> EditAttendance(Attendance attendance)
        {
            await attendanceService.UpdateAttendance(attendance);
            return RedirectToAction("AdminAttendanceList");
        }

        [HttpPost]
        public async Task<IActionResult> CheckIn()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            await attendanceService.CheckIn(userId.Value);

            return RedirectToAction("ManagerDashboard", "Dashboard");
        }


        [HttpPost]
        public async Task<IActionResult> LunchIn()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            await attendanceService.LunchIn(userId.Value);

            return RedirectToAction("ManagerDashboard", "Dashboard");
        }


        [HttpPost]
        public async Task<IActionResult> LunchOut()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            await attendanceService.LunchOut(userId.Value);

            return RedirectToAction("ManagerDashboard", "Dashboard");
        }


        [HttpPost]
        public async Task<IActionResult> CheckOut()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            await attendanceService.CheckOut(userId.Value);

            return RedirectToAction("ManagerDashboard", "Dashboard");
        }
    }
}