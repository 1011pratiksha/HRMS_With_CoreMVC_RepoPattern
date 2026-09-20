using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IProjectReportRepository
    {
        Task<int> fetchAllProjects();
        Task<int> fetchOverdueProjects();
        Task<int> fetchInProgressTasks();
        Task<int> fetchCompletedTasks();
        Task<int> fetchOnHoldTasks();
        Task<IEnumerable<ProjectReport>> fetchProjectReports();
        Task<IEnumerable<ProjectReport>> sortProjectReports(string? priorityType, string? statusType, string? sortType);
    }
}