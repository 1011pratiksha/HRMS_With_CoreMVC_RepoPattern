using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ILeaveReportRepository
    {
        Task<int> fetchTotalLeaves();

        Task<int> fetchApprovedLeaves();

        Task<int> fetchPendingLeaves();

        Task<int> fetchRejectedLeaves();

        Task<IEnumerable<LeaveReport>> fetchLeaveReports();
    }
}