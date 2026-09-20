using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly ApplicationDbContext db;

        public AdminDashboardService(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<AdminDashboardViewModel> GetDashboardData()
        {
            var dashboard = new AdminDashboardViewModel();

            // --- to get counts of employees, departments, projects, tasks, etc. ---

            dashboard.TotalEmployees = await db.User.CountAsync();

            dashboard.TotalDepartments = await db.Departments.CountAsync();

           

            dashboard.TotalProjects = await db.AllProjects.CountAsync();

            dashboard.TotalClients = await db.AllProjects
                .Select(x => x.ClientName)
                .Where(x => x != null && x != "")
                .Distinct()
                .CountAsync();


            // -- to get counts of tasks based on their status (Completed, On Hold, In Progress, Pending) ---

            dashboard.TotalTasks = await db.Task.CountAsync();

            dashboard.CompletedTasks = await db.Task.CountAsync(x => x.Status == "Completed");

            dashboard.OnHoldTasks = await db.Task.CountAsync(x => x.Status == "Onhold" || x.Status == "On Hold");

            dashboard.InProgressTasks = await db.Task.CountAsync(x => x.Status == "Inprogress" || x.Status == "In Progress");

            dashboard.PendingTasks = await db.Task.CountAsync(x => x.Status == "Pending");

            // Employees by Department

            dashboard.EmployeesByDepartment = await db.User
                .Include(x => x.Department)
                .Where(x => x.Department != null)
                .GroupBy(x => x.Department.Name)
                .Select(x => new DepartmentEmployeeViewModel
                {
                    DepartmentName = x.Key,
                    EmployeeCount = x.Count()
                })
                .OrderByDescending(x => x.EmployeeCount)
                .ToListAsync();

            // employee status counts (Active, Inactive, On Leave, Other)

            dashboard.ActiveEmployees = await db.User
                .CountAsync(x => x.Status == "Active");

            dashboard.InactiveEmployees = await db.User
                .CountAsync(x => x.Status == "Inactive");

            dashboard.OnLeaveEmployees = await db.User
                .CountAsync(x => x.Status == "On Leave");

            dashboard.OtherEmployees = dashboard.TotalEmployees
                - dashboard.ActiveEmployees
                - dashboard.InactiveEmployees
                - dashboard.OnLeaveEmployees;

            if (dashboard.OtherEmployees < 0)
            {
                dashboard.OtherEmployees = 0;
            }

            // today's attendance statistics (Present, Half Day, Absent)

            var today = DateTime.Today;

            var todayAttendance = await db.Attendance
                .Include(x => x.User)
                .Where(x => x.Date.Date == today)
                .ToListAsync();

            dashboard.AttendanceTotal = todayAttendance.Count;

            dashboard.PresentEmployees = todayAttendance
                .Count(x => x.Status == "Present");

            dashboard.HalfDayEmployees = todayAttendance
                .Count(x => x.Status == "Half Day");

            dashboard.AbsentEmployees = todayAttendance
                .Count(x => x.Status == "Absent");

            dashboard.TodayAttendance = todayAttendance
                .Select(x => new AttendanceDashboardViewModel
                {
                    UserId = x.UserId,
                    EmployeeName = x.User != null
                        ? x.User.FirstName + " " + x.User.LastName
                        : "Unknown",

                    CheckIn = x.CheckIn,
                    CheckOut = x.CheckOut,
                    Status = x.Status,
                    Late = x.Late
                })
                .ToList();

            // ---manager dashboard statistics (Team Members, Present Today, Pending Leave Requests) ---

            dashboard.TeamMembers = await db.User
                .CountAsync();

            dashboard.PresentToday = todayAttendance
                .Count(x => x.Status == "Present");

            dashboard.PendingLeaveRequests = await db.LeaveRequests
                .CountAsync(x => x.Status == "Pending");


            // --projects for the list of projects in the dashboard

            dashboard.Projects = await db.AllProjects
                .OrderByDescending(x => x.ProjectId)
                .Select(x => new ProjectDashboardViewModel
                {
                    ProjectId = x.ProjectId,
                    ProjectName = x.ProjectName,
                    EndDate = x.EndDate,
                    Priority = x.Priority,
                    Status = x.Status
                })
                .ToListAsync();

            //--- total work hours calculation from timesheets

            dashboard.TotalWorkHours = await db.Timesheets
                .SumAsync(x => (int?)x.WorkHours) ?? 0;


            // --- earnings calculation from employee salaries

            dashboard.TotalEarnings = await db.EmployeeSalaries
                .SumAsync(x => (decimal?)x.TotalSalary) ?? 0;

            // --- weekly profit calculation from employee salaries

            var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7);

            dashboard.WeeklyProfit = await db.EmployeeSalaries
                .Where(x => x.CreatedDate >= startOfWeek &&
                            x.CreatedDate < endOfWeek)
                .SumAsync(x => (decimal?)x.NetSalary) ?? 0;

            // --- new hires calculation

            var startOfMonth = new DateTime(
                today.Year,
                today.Month,
                1);

            var endOfMonth = startOfMonth.AddMonths(1);

            dashboard.NewHires = await db.User
                .CountAsync(x =>
                    x.DateOfJoining >= startOfMonth &&
                    x.DateOfJoining < endOfMonth);

            // --- job applicants calculation
            

            dashboard.TotalJobApplicants = 0;

            return dashboard;
        }
    }
}