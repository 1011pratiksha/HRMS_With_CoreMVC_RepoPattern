using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class EmpAttendanceController : Controller
    {
        private readonly IAttendanceRepository attendanceService;

        public EmpAttendanceController(IAttendanceRepository attendanceService)
        {
            this.attendanceService = attendanceService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int userId = 6;
            var todayAttendance = await attendanceService.GetTodayAttendance(userId);
            var attendanceList = await attendanceService.GetEmployeeAttendance(userId);
            ViewBag.TodayAttendance = todayAttendance;
            ViewBag.AttendanceList = attendanceList;
            return View("~/Views/Attendance/EmpAttendance.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CheckIn()
        {
            int userId = 6;
            await attendanceService.CheckIn(userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> LunchIn()
        {
            int userId = 6;
            await attendanceService.LunchIn(userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> LunchOut()
        {
            int userId = 6;
            await attendanceService.LunchOut(userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut()
        {
            int userId = 6;
            await attendanceService.CheckOut(userId);
            return RedirectToAction("Index");
        }
    }
}