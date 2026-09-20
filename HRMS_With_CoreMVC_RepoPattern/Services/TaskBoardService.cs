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

        public void AddTkBoard(TaskBoards task)
        {
            data.TaskBoards.Add(task);  
            data.SaveChanges();
        }

        public List<Projects> GetProject()
        {
            return data.AllProjects.ToList();
        }

        public List<Projects> GetProjectsWithTasks()
        {
            return data.AllProjects.Include(x => x.Task).ThenInclude(x => x.Taskmember).ThenInclude(x => x.User).Include(x => x.TaskBoard).ToList();
        }

        public List<Tasks> GetTasks(int projectId)
        {
            return data.Task.Where(x => x.ProjectId == projectId).ToList();
        }
    }
}
