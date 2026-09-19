using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ITimesheetRepository
    {
        List<Timesheet> GetAllTimesheets();
        void UpdateTimesheetStatus(List<int> timesheetIds, string status);
        void UpdateTimesheetStatus(List<int> timesheetIds, string status, string approvedBy);
        List<Timesheet> GetEmployeeTimesheets(int userId);
        void AddTimesheet(Timesheet timesheet);
        List<Projects> GetProjects();
    }
}