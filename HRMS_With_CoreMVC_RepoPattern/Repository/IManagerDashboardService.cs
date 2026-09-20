using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IManagerDashboardService
    {
        Task<AdminDashboardViewModel> GetManagerDashboardData(int managerId);
        Task<User> GetManagerProfile(int managerId);
Task<List<LeaveRequest>> GetPendingLeaveRequests(int managerId);


    }
}
