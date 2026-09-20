using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class ProjectReportRepositoryServices : IProjectReportRepository
    {
        private readonly ApplicationDbContext context;

        public ProjectReportRepositoryServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> fetchAllProjects()
        {
            return await context.AllProjects.CountAsync();
        }

        public async Task<int> fetchOverdueProjects()
        {
            return await context.AllProjects
                .Where(x => x.EndDate < DateTime.Now)
                .CountAsync();
        }

        public async Task<int> fetchInProgressTasks()
        {
            return await context.Task
                .Where(x => x.Status == "In Progress")
                .CountAsync();
        }

        public async Task<int> fetchCompletedTasks()
        {
            return await context.Task
                .Where(x => x.Status == "Completed")
                .CountAsync();
        }

        public async Task<int> fetchOnHoldTasks()
        {
            return await context.Task
                .Where(x => x.Status == "On Hold")
                .CountAsync();
        }

        public async Task<IEnumerable<ProjectReport>> fetchProjectReports()
        {
            return await context.AllProjects
                .Select(x => new ProjectReport
                {
                    ProjectId = x.ProjectId,
                    ProjectName = x.ProjectName,
                    ManagerName = x.ManagerName,
                    EndDate = x.EndDate,
                    Priority = x.Priority,
                    Status = x.Status
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectReport>> sortProjectReports(
            string? priorityType,
            string? statusType,
            string? sortType)
        {
            var query = context.AllProjects.AsQueryable();

            if (!string.IsNullOrEmpty(statusType))
            {
                query = query.Where(x => x.Status == statusType);
            }

            if (!string.IsNullOrEmpty(priorityType))
            {
                query = query.Where(x => x.Priority == priorityType);
            }

            if (sortType == "Ascending")
            {
                query = query.OrderBy(x => x.EndDate);
            }
            else if (sortType == "Descending")
            {
                query = query.OrderByDescending(x => x.EndDate);
            }

            return await query
                .Select(x => new ProjectReport
                {
                    ProjectId = x.ProjectId,
                    ProjectName = x.ProjectName,
                    ManagerName = x.ManagerName,
                    EndDate = x.EndDate,
                    Priority = x.Priority,
                    Status = x.Status
                })
                .ToListAsync();
        }
    }
}