using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IEmployeeDashboardService
    {
        Task<User> GetEmployeeProfile(int employeeId);

        Task<Attendance> GetTodayAttendance(int employeeId);

        Task<List<LeaveRequest>> GetEmployeeLeaveRequests(int employeeId);

        Task<List<Projects>> GetEmployeeProjects(int employeeId);

        Task<List<Tasks>> GetEmployeeTasks(int employeeId);

        Task<int> GetTotalTasks(int employeeId);

        Task<int> GetCompletedTasks(int employeeId);

        Task<int> GetPendingTasks(int employeeId);

        Task<int> GetInProgressTasks(int employeeId);

        Task<decimal> GetTaskPerformance(int employeeId);

        Task<decimal> GetAttendancePerformance(int employeeId);

        Task<decimal> GetOverallPerformance(int employeeId);
    }
}

