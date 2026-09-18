using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAttendance();
        Task<List<Attendance>> GetFilteredAttendance(DateTime? startDate, DateTime? endDate, int? departmentId, string status, string search, string sort);
        Task<Attendance> GetAttendanceById(int id);
        Task UpdateAttendance(Attendance attendance);
        Task<int> GetTotalEmployees();
        Task<List<Department>> GetDepartments();
        Task<Attendance> GetTodayAttendance(int userId);
        Task<List<Attendance>> GetEmployeeAttendance(int userId);
        Task<Attendance> CheckIn(int userId);
        Task<Attendance> LunchIn(int userId);
        Task<Attendance> LunchOut(int userId);
        Task<Attendance> CheckOut(int userId);
    }
}