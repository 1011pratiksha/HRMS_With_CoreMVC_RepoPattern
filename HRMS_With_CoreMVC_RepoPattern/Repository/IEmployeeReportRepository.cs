using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IEmployeeReportRepository
    {
        Task<int> fetchAllEmployees();

        Task<int> fetchActiveEmployees();

        Task<int> fetchInactiveEmployees();

        Task<int> fetchTotalDepartments();

        Task<int> fetchTotalRoles();

        Task<IEnumerable<EmployeeReport>> fetchEmployeeReports();

        Task<IEnumerable<EmployeeReport>> sortEmployeeReports(
            string? statusType,
            string? sortType);
    }
}