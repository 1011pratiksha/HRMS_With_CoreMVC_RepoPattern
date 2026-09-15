using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IEmployeeReportRepository
    {
        List<EmployeeReport> FetchAllEmployeeReport();

    }
}
