using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class ProjectService : IProjectService
    {
        public readonly ApplicationDbContext data;
        public ProjectService(ApplicationDbContext context) 
        {
            data = context;
        }

        public void AddProject(Projects pro, IFormFile logo, IFormFile file, int[] Users)
        {
            if(logo != null)
            {
                string path = "wwwroot/Logo/" + logo.FileName;

                logo.CopyTo(new FileStream(path, FileMode.Create));

                pro.LogoPath = "/Logo/" + logo.FileName;
            }

            if (file != null)
            {
                string path = "wwwroot/File/" + file.FileName;

                file.CopyTo(new FileStream(path, FileMode.Create));

                pro.FilePath = "/File/" + file.FileName;
            }

            pro.Users = data.User.Where(x => Users.Contains(x.UserId)).ToList();

            data.AllProjects.Add(pro);
            data.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var findProject = data.AllProjects.Find(id);

            if (findProject != null)
            {
                data.AllProjects.Remove(findProject);
            }
            data.SaveChanges();
        }

        public Projects GetById(int id)
        {
            return data.AllProjects.Include(x => x.Users).FirstOrDefault(x => x.ProjectId == id);
 
        }

        public List<User> GetManagers()
        {
            return data.User.Where(x => x.Role.RoleName == "Manager").ToList();
        }

        public List<Projects> GetProjects()
        {
            return data.AllProjects.Include(x => x.Users).Include(x => x.Task).ToList();
        }

        public List<User> getUser()
        {
            return data.User.ToList();
        }

        public void UpdateProject(Projects pro, IFormFile logo, IFormFile file, int[] Users)
        {
            var oldData = data.AllProjects.Include(x => x.Users).FirstOrDefault(x => x.ProjectId == pro.ProjectId);

            if (oldData != null)
            {
                oldData.ProjectName = pro.ProjectName;
                oldData.ClientName = pro.ClientName;
                oldData.Description = pro.Description;
                oldData.StartDate = pro.StartDate;
                oldData.EndDate = pro.EndDate;
                oldData.Priority = pro.Priority;
                oldData.ProjectValue = pro.ProjectValue;
                oldData.PriceType = pro.PriceType;
                oldData.Status = pro.Status;
                oldData.ManagerName = pro.ManagerName;

            }

            if (logo != null)
            {
                string path = "wwwroot/Logo/" + logo.FileName;

                logo.CopyTo(new FileStream(path, FileMode.Create));

                oldData.LogoPath = "/Logo/" + logo.FileName;
            }

            if (file != null)
            {
                string path = "wwwroot/File/" + file.FileName;

                file.CopyTo(new FileStream(path, FileMode.Create));

                oldData.FilePath = "/File/" + file.FileName;
            }

            oldData.Users = data.User.Where(x => Users.Contains(x.UserId)).ToList();

            data.SaveChanges();
        }
    }
}
