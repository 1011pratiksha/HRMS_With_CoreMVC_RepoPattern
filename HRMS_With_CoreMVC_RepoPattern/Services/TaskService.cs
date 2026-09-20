
using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext data;

        public TaskService(ApplicationDbContext context)
        {
            data = context;
        }

        public async Task AddTask(Tasks tk, IFormFile file, int[] Users)
        {

            if (file != null)
            {
                string path = "wwwroot/TaskFile/" + file.FileName;

                await file.CopyToAsync(new FileStream(path, FileMode.Create));

                tk.FilePath = "/TaskFile/" + file.FileName;
            }

            data.Task.Add(tk);
            await data.SaveChangesAsync();

            foreach (var userId in Users)
            {
                TaskMembers member = new TaskMembers();

                member.TaskId = tk.TaskId;
                member.UserId = userId;

                data.Taskmember.Add(member);
            }

            await data.SaveChangesAsync();

        }

        public async Task<List<Projects>> GetProject()
        {
            return await data.AllProjects.ToListAsync();
        }

        public async Task<List<Tasks>> GetTask()
        {
            return await data.Task.Include(x => x.Project).ToListAsync();
        }

        public async Task<List<User>> GetUsers(int projectId)
        {
            var project = await data.AllProjects.Include(x => x.Users).FirstOrDefaultAsync(x => x.ProjectId == projectId);

            if (project == null)
            {
                return new List<User>();
            }

            return project.Users;
        }
    }
}
