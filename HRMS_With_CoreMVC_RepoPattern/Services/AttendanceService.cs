using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class AttendanceService : IAttendanceRepository
    {
        private readonly ApplicationDbContext db;
        public AttendanceService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<Attendance>> GetAttendance()
        {
            var data = await db.Attendance
                .Include(x => x.User)
                .ThenInclude(x => x.Department)
                .ToListAsync();
            return data;
        }
        public async Task<List<Attendance>> GetFilteredAttendance(DateTime? startDate, DateTime? endDate, int? departmentId, string status, string search, string sort)
        {
            var data = db.Attendance
                .Include(x => x.User)
                .ThenInclude(x => x.Department)
                .AsQueryable();
            if (startDate.HasValue)
            {
                data = data.Where(x => x.Date.Date >= startDate.Value.Date);
            }
            if (endDate.HasValue)
            {
                data = data.Where(x => x.Date.Date <= endDate.Value.Date);
            }
            if (departmentId.HasValue)
            {
                data = data.Where(x => x.User.DepartmentId == departmentId.Value);
            }
            if (!string.IsNullOrEmpty(status) && status != "All")
            {
                data = data.Where(x => x.Status == status);
            }
            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(x =>
                    x.User.FirstName.Contains(search) ||
                    x.User.LastName.Contains(search));
            }
            if (sort == "Oldest First")
            {
                data = data.OrderBy(x => x.Date);
            }
            else
            {
                data = data.OrderByDescending(x => x.Date);
            }
            return await data.ToListAsync();
        }
        public async Task<Attendance> GetAttendanceById(int id)
        {
            var data = await db.Attendance
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.AttendanceId == id);
            return data;
        }
        public async Task UpdateAttendance(Attendance attendance)
        {
            var data = await db.Attendance
                .FirstOrDefaultAsync(x => x.AttendanceId == attendance.AttendanceId);
            if (data != null)
            {
                data.Date = attendance.Date;
                data.CheckIn = attendance.CheckIn;
                data.CheckOut = attendance.CheckOut;
                data.BreakHours = attendance.BreakHours;
                data.Late = attendance.Late;
                data.ProductionHours = attendance.ProductionHours;
                data.Status = attendance.Status;
                await db.SaveChangesAsync();
            }
        }
        public async Task<int> GetTotalEmployees()
        {
            return await db.Attendance
                .Select(x => x.UserId)
                .Distinct()
                .CountAsync();
        }
        public async Task<List<Department>> GetDepartments()
        {
            return await db.Departments
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
        public async Task<Attendance> GetTodayAttendance(int userId)
        {
            var today = DateTime.Today;
            var data = await db.Attendance
                .Include(x => x.User)
                .FirstOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.Date.Date == today);
            return data;
        }
        public async Task<List<Attendance>> GetEmployeeAttendance(int userId)
        {
            var data = await db.Attendance
                .Include(x => x.User)
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
            return data;
        }
        public async Task<Attendance> CheckIn(int userId)
        {
            var attendance = await GetTodayAttendance(userId);
            if (attendance == null)
            {
                attendance = new Attendance
                {
                    UserId = userId,
                    Date = DateTime.Today,
                    CheckIn = DateTime.Now,
                    Status = "Present",
                    WorkingHours = 0,
                    ProductionHours = 0,
                    OvertimeHours = 0,
                    BreakHours = 0,
                    Late = 0
                };
                db.Attendance.Add(attendance);
            }
            else
            {
                attendance.CheckIn = DateTime.Now;
                attendance.Status = "Present";
            }
            await db.SaveChangesAsync();
            return attendance;
        }
        public async Task<Attendance> LunchIn(int userId)
        {
            var attendance = await GetTodayAttendance(userId);
            if (attendance != null)
            {
                attendance.LunchIn = DateTime.Now;
                await db.SaveChangesAsync();
            }
            return attendance;
        }
        public async Task<Attendance> LunchOut(int userId)
        {
            var attendance = await GetTodayAttendance(userId);
            if (attendance != null)
            {
                attendance.LunchOut = DateTime.Now;
                if (attendance.LunchIn != null)
                {
                    attendance.BreakHours =
                        (decimal)(DateTime.Now - attendance.LunchIn.Value).TotalHours;
                }
                await db.SaveChangesAsync();
            }
            return attendance;
        }
        public async Task<Attendance> CheckOut(int userId)
        {
            var attendance = await GetTodayAttendance(userId);
            if (attendance != null)
            {
                attendance.CheckOut = DateTime.Now;
                if (attendance.CheckIn != null)
                {
                    attendance.WorkingHours =
                        (decimal)(attendance.CheckOut.Value - attendance.CheckIn.Value).TotalHours;
                }
                if (attendance.LunchIn != null && attendance.LunchOut != null)
                {
                    attendance.BreakHours =
                        (decimal)(attendance.LunchOut.Value - attendance.LunchIn.Value).TotalHours;
                }
                attendance.ProductionHours = attendance.WorkingHours - attendance.BreakHours;
                if (attendance.ProductionHours > 8)
                {
                    attendance.OvertimeHours = attendance.ProductionHours - 8;
                }
                else
                {
                    attendance.OvertimeHours = 0;
                }
                await db.SaveChangesAsync();
            }
            return attendance;
        }
    }
}