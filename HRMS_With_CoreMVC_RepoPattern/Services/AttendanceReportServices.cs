using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class AttendanceReportServices : IAttendanceReportRepository
    {
        private readonly ApplicationDbContext context;

        public AttendanceReportServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> fetchTotalAttendance()
        {
            return await context.Attendance.CountAsync();
        }

        public async Task<int> fetchPresentAttendance()
        {
            return await context.Attendance
                .Where(x => x.Status == "Present")
                .CountAsync();
        }

        public async Task<int> fetchAbsentAttendance()
        {
            return await context.Attendance
                .Where(x => x.Status == "Absent")
                .CountAsync();
        }

        public async Task<IEnumerable<AttendanceReport>> fetchAttendanceReports()
        {
            var attendance = await context.Attendance
                .Select(x => new AttendanceReport
                {
                    AttendanceId = x.AttendanceId,
                    UserId = x.UserId,
                    UserName = x.User.FirstName + " " + x.User.LastName,
                    ProfilePicture = x.User.ProfilePicture,
                    Date = x.Date,
                    CheckIn = x.CheckIn,
                    CheckOut = x.CheckOut,
                    LunchIn = x.LunchIn,
                    LunchOut = x.LunchOut,
                    Status = x.Status,
                    WorkingHours = x.WorkingHours,
                    OvertimeHours = x.OvertimeHours,
                    BreakHours = x.BreakHours,
                    Late = x.Late,
                    ProductionHours = x.ProductionHours
                })
                .ToListAsync();

            return attendance;
        }

        public async Task<IEnumerable<AttendanceReport>> sortAttendanceReports(
            string? statusType,
            string? sortType)
        {
            var query = context.Attendance.AsQueryable();

            if (!string.IsNullOrEmpty(statusType))
            {
                query = query.Where(x => x.Status == statusType);
            }

            if (sortType == "Ascending")
            {
                query = query.OrderBy(x => x.Date);
            }
            else if (sortType == "Descending")
            {
                query = query.OrderByDescending(x => x.Date);
            }

            var attendance = await query
                .Select(x => new AttendanceReport
                {
                    AttendanceId = x.AttendanceId,
                    UserId = x.UserId,
                    UserName = x.User.FirstName + " " + x.User.LastName,
                    ProfilePicture = x.User.ProfilePicture,
                    Date = x.Date,
                    CheckIn = x.CheckIn,
                    CheckOut = x.CheckOut,
                    LunchIn = x.LunchIn,
                    LunchOut = x.LunchOut,
                    Status = x.Status,
                    WorkingHours = x.WorkingHours,
                    OvertimeHours = x.OvertimeHours,
                    BreakHours = x.BreakHours,
                    Late = x.Late,
                    ProductionHours = x.ProductionHours
                })
                .ToListAsync();

            return attendance;
        }
    }
}