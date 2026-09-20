using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repositories
{
    public interface IDailyReportRepository
    {
        Task<IEnumerable<DailyReport>> GetDailyReportsAsync();
    }
}