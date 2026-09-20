using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repositories
{
    public interface ITaskReportRepository
    {
        Task<IEnumerable<TaskReport>> GetTaskReportsAsync();
    }
}