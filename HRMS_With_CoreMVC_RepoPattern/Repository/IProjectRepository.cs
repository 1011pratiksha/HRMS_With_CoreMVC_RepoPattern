using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IProjectRepository
    {
        Task<int> fetchAllProjects();
        Task<int> fetchOnHoldProjects();
        Task<int> fetchOverdueProjects();
        Task<IEnumerable<ProjectReport>> fetchProjectReports();

        Task<IEnumerable<ProjectReport>> sortProjectReports(string? priorityType, string? statusType, string? sortType);
    }
}
