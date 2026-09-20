using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Repositories
{
    public class TaskReportService : ITaskReportRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskReport>> GetTaskReportsAsync()
        {
            return await _context.Task
                .Include(t => t.Project)
                .Select(t => new TaskReport
                {
                    TaskId = t.TaskId,
                    Title = t.Title,
                    ProjectName = t.Project.ProjectName,
                    Deadline = t.Deadline,
                    Priority = t.Priority,
                    Status = t.Status
                })
                .ToListAsync();
        }
    }
}