using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;
using HRMS_With_CoreMVC_RepoPattern.Repository;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IAdminDashboardService adminDashboardService;
        private readonly IAttendanceRepository attendanceService;
        private readonly IManagerDashboardService managerDashboardService;
        public readonly IEmployeeDashboardService employeeDashboardService;



        public DashboardController(
    IAdminDashboardService adminDashboardService,
    IManagerDashboardService managerDashboardService,
    IAttendanceRepository attendanceService,
    IEmployeeDashboardService employeeDashboardService)
        {
            this.adminDashboardService = adminDashboardService;
            this.managerDashboardService = managerDashboardService;
            this.attendanceService = attendanceService;
            this.employeeDashboardService = employeeDashboardService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LogIn()
        {
            string Role = "Admin";  ///Employee/Manager

            if (Role == "Admin")
            {
                return RedirectToAction("AdminDashboard");
            }

            if (Role == "Manager")
            {
                return RedirectToAction("ManagerDashboard");
            }

            if (Role == "Employee")
            {
                return RedirectToAction("EmployeeDashboard");
            }
            else
            {
                TempData["error"] = "Invalid Role";
                return View();
            }
        }

        public async Task<IActionResult> AdminDashboard()
        {
            var dashboard = await adminDashboardService.GetDashboardData();

            return View(dashboard);
        }



public async Task<IActionResult> ManagerDashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            var dashboard =
                await managerDashboardService.GetManagerDashboardData(userId.Value);

            var attendance =
                await attendanceService.GetTodayAttendance(userId.Value);

            var manager =
                await managerDashboardService.GetManagerProfile(userId.Value);
            var pendingLeaveRequests = await managerDashboardService.GetPendingLeaveRequests(userId.Value); 
            ViewBag.PendingLeaveRequests = pendingLeaveRequests;

            ViewBag.TodayAttendance = attendance;
            ViewBag.ManagerProfile = manager;

            return View(dashboard);
        }

      
[HttpGet]
public async Task<IActionResult> EmployeeDashboard()
        {
            // Get logged-in employee ID
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            // --- to get the employee's profile

            var employee =
                await employeeDashboardService.GetEmployeeProfile(userId.Value);

            if (employee == null)
            {
                return NotFound();
            }


            // --- to get today's attendance

            var attendance =
                await employeeDashboardService.GetTodayAttendance(userId.Value);


            // -----to get leave details

            var leaveRequests =
                await employeeDashboardService.GetEmployeeLeaveRequests(userId.Value);

            ViewBag.TotalLeaves = leaveRequests.Count;

            ViewBag.PendingLeaves =leaveRequests.Count(x => x.Status == "Pending");

            ViewBag.ApprovedLeaves =leaveRequests.Count(x => x.Status == "Approved");

            ViewBag.RejectedLeaves =leaveRequests.Count(x => x.Status == "Rejected");


           

            var projects = await employeeDashboardService.GetEmployeeProjects(userId.Value);


            

            var tasks = await employeeDashboardService.GetEmployeeTasks(userId.Value);


            // -- to get total tasks, completed tasks, pending tasks, and in-progress tasks

            var totalTasks = await employeeDashboardService.GetTotalTasks(userId.Value);

            var completedTasks = await employeeDashboardService.GetCompletedTasks(userId.Value);

            var pendingTasks = await employeeDashboardService.GetPendingTasks(userId.Value);

            var inProgressTasks = await employeeDashboardService.GetInProgressTasks(userId.Value);


            // --- to get task performance, attendance performance, and overall performance

            var taskPerformance =await employeeDashboardService.GetTaskPerformance(userId.Value);

            var attendancePerformance =await employeeDashboardService.GetAttendancePerformance(userId.Value);

            var overallPerformance =await employeeDashboardService.GetOverallPerformance(userId.Value);


            //-- to getviewbag values for the dashboard

            ViewBag.TodayAttendance = attendance;

            ViewBag.LeaveRequests = leaveRequests;

            ViewBag.EmployeeProjects = projects;

            ViewBag.EmployeeTasks = tasks;

            ViewBag.TotalTasks = totalTasks;

            ViewBag.CompletedTasks = completedTasks;

            ViewBag.PendingTasks = pendingTasks;

            ViewBag.InProgressTasks = inProgressTasks;

            ViewBag.TaskPerformance = taskPerformance;

            ViewBag.AttendancePerformance = attendancePerformance;

            ViewBag.OverallPerformance = overallPerformance;


            // --- to display working hours, break hours, and production hours in the dashboard

            decimal workingHours = 0;
            decimal breakHours = 0;
            decimal productionHours = 0;

            if (attendance != null)
            {
                workingHours = attendance.WorkingHours;
                breakHours = attendance.BreakHours;
                productionHours = attendance.ProductionHours;
            }

            ViewBag.WorkingHours =Math.Round(workingHours, 2);

            ViewBag.BreakHours =Math.Round(breakHours, 2);

            ViewBag.ProductionHours =Math.Round(productionHours, 2);


            return View(employee);
        }


    }
}