
using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class EmployeeDashboardService : IEmployeeDashboardService
    {
        private readonly ApplicationDbContext db;

        public EmployeeDashboardService(ApplicationDbContext context)
        {
            db = context;
        }

        // -- employee profile

        public async Task<User> GetEmployeeProfile(int employeeId)
        {
            return await db.User
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .FirstOrDefaultAsync(x => x.UserId == employeeId);
        }


        //----- to get todays attendance of employee

        public async Task<Attendance> GetTodayAttendance(int employeeId)
        {
            var today = DateTime.Today;

            return await db.Attendance
                .FirstOrDefaultAsync(x =>
                    x.UserId == employeeId &&
                    x.Date.Date == today);
        }


        //----- to get employee leave requests

        public async Task<List<LeaveRequest>> GetEmployeeLeaveRequests(int employeeId)
        {
            return await db.LeaveRequests
                .Include(x => x.MasterLeaveType)
                .Where(x => x.UserId == employeeId)
                .OrderByDescending(x => x.StartDate)
                .ToListAsync();
        }


        //----- to get employee projects

        public async Task<List<Projects>> GetEmployeeProjects(int employeeId)
        {
            return await db.AllProjects
                .Where(x => x.Users.Any(u => u.UserId == employeeId))
                .OrderByDescending(x => x.ProjectId)
                .ToListAsync();
        }


        //---- to get employee tasks

        public async Task<List<Tasks>> GetEmployeeTasks(int employeeId)
        {
            return await db.Taskmember
                .Include(x => x.Task)
                .ThenInclude(x => x.Project)
                .Where(x => x.UserId == employeeId)
                .Select(x => x.Task)
                .OrderByDescending(x => x.TaskId)
                .ToListAsync();
        }


        // --- to get total tasks assigned to employee

        public async Task<int> GetTotalTasks(int employeeId)
        {
            return await db.Taskmember
                .Where(x => x.UserId == employeeId)
                .Select(x => x.TaskId)
                .Distinct()
                .CountAsync();
        }


        // ---- to get completed tasks assigned to employee

        public async Task<int> GetCompletedTasks(int employeeId)
        {
            return await db.Taskmember
                .Include(x => x.Task)
                .Where(x =>
                    x.UserId == employeeId &&
                    x.Task.Status == "Completed")
                .Select(x => x.TaskId)
                .Distinct()
                .CountAsync();
        }


        // ---- to get pending tasks assigned to employee

        public async Task<int> GetPendingTasks(int employeeId)
        {
            return await db.Taskmember
                .Include(x => x.Task)
                .Where(x =>
                    x.UserId == employeeId &&
                    x.Task.Status == "Pending")
                .Select(x => x.TaskId)
                .Distinct()
                .CountAsync();
        }


        // ---- to get in-progress tasks assigned to employee

        public async Task<int> GetInProgressTasks(int employeeId)
        {
            return await db.Taskmember
                .Include(x => x.Task)
                .Where(x =>
                    x.UserId == employeeId &&
                    x.Task.Status == "In Progress")
                .Select(x => x.TaskId)
                .Distinct()
                .CountAsync();
        }


        // ---- to get task performance

        public async Task<decimal> GetTaskPerformance(int employeeId)
        {
            var totalTasks = await GetTotalTasks(employeeId);

            if (totalTasks == 0)
            {
                return 0;
            }

            var completedTasks =
                await GetCompletedTasks(employeeId);

            return Math.Round(
                ((decimal)completedTasks / totalTasks) * 100,
                2);
        }


        // ---- to get attendance performance

        public async Task<decimal> GetAttendancePerformance(int employeeId)
        {
            var attendance =
                await GetTodayAttendance(employeeId);

            if (attendance == null)
            {
                return 0;
            }

            var productionHours =
                attendance.ProductionHours;

            if (productionHours <= 0)
            {
                return 0;
            }

            var performance =
                (productionHours / 8) * 100;

            if (performance > 100)
            {
                performance = 100;
            }

            return Math.Round(performance, 2);
        }


        // ---- to get overall performance

        public async Task<decimal> GetOverallPerformance(int employeeId)
        {
            var taskPerformance =
                await GetTaskPerformance(employeeId);

            var attendancePerformance =
                await GetAttendancePerformance(employeeId);

            return Math.Round(
                (taskPerformance + attendancePerformance) / 2,
                2);
        }
    }
}
