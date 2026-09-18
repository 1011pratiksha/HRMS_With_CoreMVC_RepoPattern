using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;
using HRMS_With_CoreMVC_RepoPattern.Data;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class TimesheetService : ITimesheetRepository
    {
        private readonly ApplicationDbContext db;
        public TimesheetService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Timesheet> GetAllTimesheets()
        {
            var data = db.Timesheets
                .Include(x => x.User)
                .Include(x => x.Projects)
                .ToList();
            return data;
        }
        public void UpdateTimesheetStatus(List<int> timesheetIds, string status)
        {
            var timesheets = db.Timesheets
                .Where(x => timesheetIds.Contains(x.TimesheetId))
                .ToList();
            foreach (var timesheet in timesheets)
            {
                timesheet.Status = status;
                timesheet.ApprovedBy = "Manager";
                timesheet.ApprovedAt = DateTime.Now;
            }
            db.SaveChanges();
        }
        public List<Timesheet> GetEmployeeTimesheets(int userId)
        {
            var data = db.Timesheets
                .Include(x => x.User)
                .Include(x => x.Projects)
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Date)
                .ToList();
            return data;
        }
        public void AddTimesheet(Timesheet timesheet)
        {
            db.Timesheets.Add(timesheet);
            db.SaveChanges();
        }
        public void UpdateTimesheetStatus(List<int> timesheetIds, string status, string approvedBy)
        {
            var timesheets = db.Timesheets
                .Where(x => timesheetIds.Contains(x.TimesheetId))
                .ToList();
            foreach (var timesheet in timesheets)
            {
                timesheet.Status = status;
                timesheet.ApprovedBy = approvedBy;
                timesheet.ApprovedAt = DateTime.Now;
            }
            db.SaveChanges();
        }
        public List<Projects> GetProjects()
        {
            return db.AllProjects
                .OrderBy(x => x.ProjectName)
                .ToList();
        }
    }
}