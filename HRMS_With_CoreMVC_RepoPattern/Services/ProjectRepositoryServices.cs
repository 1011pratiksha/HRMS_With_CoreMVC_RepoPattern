using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class ProjectRepositoryServices : IProjectRepository
    {
        private readonly ApplicationDbContext context;

        public ProjectRepositoryServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> fetchAllProjects()
        {
            var data = await context.AllProjects
                .Select(s => s.ProjectId)
                .CountAsync();

            return data;
        }

        public async Task<int> fetchOnHoldProjects()
        {
            var data = await context.AllProjects
                .Where(s => s.Status == "Inactive")
                .CountAsync();

            return data;
        }

        public async Task<int> fetchOverdueProjects()
        {
            var data = await context.AllProjects
                .Where(s => s.EndDate < DateTime.Now)
                .CountAsync();

            return data;
        }

        public async Task<IEnumerable<ProjectReport>> fetchProjectReports()
        {
            var data = await context.AllProjects
                .Select(s => new ProjectReport
                {
                    ProjectId = s.ProjectId,
                    ProjectName = s.ProjectName,
                    ManagerName = s.ManagerName,
                    EndDate = s.EndDate,
                    Priority = s.Priority,
                    Status = s.Status
                })
                .ToListAsync();

            return data;
        }

        public async Task<IEnumerable<ProjectReport>> sortProjectReports(
            string? priorityType,
            string? statusType,
            string? sortType)
        {
            var query = context.AllProjects.AsQueryable();

            if (!string.IsNullOrEmpty(statusType))
            {
                query = query.Where(s => s.Status == statusType);
            }

            if (!string.IsNullOrEmpty(priorityType))
            {
                query = query.Where(s => s.Priority == priorityType);
            }

            if (sortType == "Ascending")
            {
                query = query.OrderBy(s => s.EndDate);
            }
            else if (sortType == "Descending")
            {
                query = query.OrderByDescending(s => s.EndDate);
            }

            var data = await query
                .Select(s => new ProjectReport
                {
                    ProjectId = s.ProjectId,
                    ProjectName = s.ProjectName,
                    ManagerName = s.ManagerName,
                    EndDate = s.EndDate,
                    Priority = s.Priority,
                    Status = s.Status
                })
                .ToListAsync();

            return data;
        }
    }
}