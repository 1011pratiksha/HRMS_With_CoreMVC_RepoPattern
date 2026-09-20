using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Repositories
{
    public class DailyReportService : IDailyReportRepository
    {
        private readonly ApplicationDbContext _context;

        public DailyReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DailyReport>> GetDailyReportsAsync()
        {
            return await _context.Attendance
                .Include(a => a.User)
                .ThenInclude(u => u.Department)
                .Select(a => new DailyReport
                {
                    UserName = a.User.FirstName + " " + a.User.LastName,
                    Department = a.User.Department.Name,
                    Date = a.Date,
                    Status = a.Status
                })
                .ToListAsync();
        }
    }
}