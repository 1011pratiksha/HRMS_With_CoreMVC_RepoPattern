using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class ManagerDashboardService : IManagerDashboardService
    {
        private readonly ApplicationDbContext db;

        public ManagerDashboardService(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<AdminDashboardViewModel> GetManagerDashboardData(int managerId)
        {
            var dashboard = new AdminDashboardViewModel();

            //----- to get the manager's details and their projects

            var manager = await db.User
                .FirstOrDefaultAsync(x => x.UserId == managerId);

            if (manager == null)
            {
                return dashboard;
            }
            dashboard.Projects = await db.AllProjects
    .Where(x => x.ManagerName == manager.FirstName + " " + manager.LastName)
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

            // --- to get the team members under the manager's department

            var teamMembers = await db.User
                .Where(x =>
                    x.DepartmentId == manager.DepartmentId &&
                    x.RoleId == 3)
                .ToListAsync();

            dashboard.TeamMembers = teamMembers.Count;

            //-- to get today's attendance for the team members

            var today = DateTime.Today;

            var teamUserIds = teamMembers
                .Select(x => x.UserId)
                .ToList();

            var todayAttendance = await db.Attendance
                .Include(x => x.User)
                .Where(x =>
                    teamUserIds.Contains(x.UserId) &&
                    x.Date.Date == today)
                .ToListAsync();

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

            dashboard.PresentToday = todayAttendance
                .Count(x => x.Status == "Present");


            var totalProductionHours = todayAttendance
    .Sum(x => x.ProductionHours);

            var totalExpectedHours = teamMembers.Count * 8;

            if (totalExpectedHours > 0)
            {
                dashboard.TeamPerformance =
                    Math.Round((totalProductionHours / totalExpectedHours) * 100, 2);
            }
            else
            {
                dashboard.TeamPerformance = 0;
            }

            // --- to get pending leave requests for the team members

            dashboard.PendingLeaveRequests = await db.LeaveRequests
                .Where(x =>
                    teamUserIds.Contains(x.UserId) &&
                    x.Status == "Pending")
                .CountAsync();

            // --- to get pending tasks for the team members

            dashboard.PendingTasks = await db.Task
                .CountAsync(x => x.Status == "Pending");

            return dashboard;
        }
       
public async Task<User> GetManagerProfile(int managerId)
        {
            return await db.User
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .FirstOrDefaultAsync(x => x.UserId == managerId);
        }
        public async Task<List<LeaveRequest>> GetPendingLeaveRequests(int managerId)
        {
            var manager = await db.User
                .FirstOrDefaultAsync(x => x.UserId == managerId);

            if (manager == null)
            {
                return new List<LeaveRequest>();
            }

            var teamUserIds = await db.User
                .Where(x =>
                    x.DepartmentId == manager.DepartmentId &&
                    x.RoleId == 3)
                .Select(x => x.UserId)
                .ToListAsync();

            return await db.LeaveRequests
                .Include(x => x.User)
                .Include(x => x.MasterLeaveType)
                .Where(x =>
                    teamUserIds.Contains(x.UserId) &&
                    x.Status == "Pending")
                .OrderBy(x => x.StartDate)
                .ToListAsync();
        }
    }
}