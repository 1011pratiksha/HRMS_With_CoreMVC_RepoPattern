
using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class TaskBoardService : ITaskBoardService
    {
        private readonly ApplicationDbContext data;

        public TaskBoardService(ApplicationDbContext context)
        {
            data = context;
        }

        public async Task AddTkBoard(TaskBoards task)
        {
            data.TaskBoards.Add(task);

            await data.SaveChangesAsync();
        }

        public async Task<List<Projects>> GetProject()
        {
            return await data.AllProjects.ToListAsync();
        }

        public async Task<List<Projects>> GetProjectsWithTasks()
        {
            return await data.AllProjects.Include(x => x.Task).ThenInclude(x => x.Taskmember).ThenInclude(x => x.User).Include(x => x.TaskBoard).ToListAsync();
        }

        public async Task<List<Tasks>> GetTasks(int projectId)
        {
            return await data.Task.Where(x => x.ProjectId == projectId).ToListAsync();
        }
    }
}
