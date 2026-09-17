using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IAttendanceReportRepository
    {
        Task<int> fetchTotalAttendance();

        Task<int> fetchPresentAttendance();

        Task<int> fetchAbsentAttendance();

        Task<IEnumerable<AttendanceReport>> fetchAttendanceReports();

        Task<IEnumerable<AttendanceReport>> sortAttendanceReports(
            string? statusType,
            string? sortType);
    }
}