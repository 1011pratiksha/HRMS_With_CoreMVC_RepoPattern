using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext data;
        public TaskService(ApplicationDbContext context) 
        {
            data=context;
        }

        //public List<Tasks> AddTask(Tasks tk, IFormFile file, int[] Users)
        //{

        //    //if (file != null)
            //{
            //    string path = "wwwroot/TaskFile/" + file.FileName;

            //    file.CopyTo(new FileStream(path, FileMode.Create));

            //    pro.LogoPath = "/TaskFile/" + file.FileName;
            //}

            //file.Users = data.Users.Where(x => Users.Contains(x.UserId)).ToList();

            //      pro.Users = data.User.Where(x => Users.Contains(x.UserId)).ToList();


            //data.Task.Add(tk, file, Users);
            //data.SaveChanges();

        //}
    }
}
