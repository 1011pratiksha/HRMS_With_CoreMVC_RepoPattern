using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IAdminDashboardService
    {
        Task<AdminDashboardViewModel> GetDashboardData();
    }
}