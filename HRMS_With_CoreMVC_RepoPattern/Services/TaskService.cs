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
            data=context;
        }

        public void AddTask(Tasks tk, IFormFile file, int[] Users)
        {

            if (file != null)
            {
                string path = "wwwroot/TaskFile/" + file.FileName;

                file.CopyTo(new FileStream(path, FileMode.Create));

                tk.FilePath = "/TaskFile/" + file.FileName;
            }

            data.Task.Add(tk);
            data.SaveChanges();

            foreach (var userId in Users)
            {
                TaskMembers member = new TaskMembers();

                member.TaskId = tk.TaskId;
                member.UserId = userId;

                data.Taskmember.Add(member);
            }

            data.SaveChanges();

        }

        public List<Projects> GetProject()
        {
            return data.AllProjects.ToList();
        }

        public List<Tasks> GetTask()
        {
            return data.Task.Include(x => x.Project).ToList();
        }

        public List<User> GetUsers(int projectId)
        {
            var project = data.AllProjects.Include(x => x.Users).FirstOrDefault(x => x.ProjectId == projectId);

            if (project == null)
            {
                return new List<User>();
            }

            return project.Users;
        }
    }
}
