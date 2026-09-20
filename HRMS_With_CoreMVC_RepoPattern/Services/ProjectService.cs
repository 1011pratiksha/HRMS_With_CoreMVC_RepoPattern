
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

        public async Task AddProject(Projects pro, IFormFile logo, IFormFile file, int[] Users)
        {
            if (logo != null)
            {
                string path = "wwwroot/Logo/" + logo.FileName;

                await logo.CopyToAsync(new FileStream(path, FileMode.Create));

                pro.LogoPath = "/Logo/" + logo.FileName;
            }

            if (file != null)
            {
                string path = "wwwroot/File/" + file.FileName;

                await file.CopyToAsync(new FileStream(path, FileMode.Create));

                pro.FilePath = "/File/" + file.FileName;
            }

            pro.Users = await data.User.Where(x => Users.Contains(x.UserId)).ToListAsync();

            data.AllProjects.Add(pro);
            await data.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            var findProject = await data.AllProjects.FindAsync(id);

            if (findProject != null)
            {
                data.AllProjects.Remove(findProject);
            }
            await data.SaveChangesAsync();
        }

        public async Task<Projects> GetById(int id)
        {
            return await data.AllProjects.Include(x => x.Users).FirstOrDefaultAsync(x => x.ProjectId == id);

        }

        public async Task<List<User>> GetManagers()
        {
            return await data.User.Where(x => x.Role.RoleName == "Manager").ToListAsync();
        }

        public async Task<List<Projects>> GetProjects()
        {
            return await data.AllProjects.Include(x => x.Users).ToListAsync();
        }

        public async Task<List<User>> getUser()
        {
            return await data.User.ToListAsync();
        }

        public async Task UpdateProject(Projects pro, IFormFile logo, IFormFile file, int[] Users)
        {
            var oldData = await data.AllProjects.Include(x => x.Users).FirstOrDefaultAsync(x => x.ProjectId == pro.ProjectId);

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

                await logo.CopyToAsync(new FileStream(path, FileMode.Create));

                oldData.LogoPath = "/Logo/" + logo.FileName;
            }

            if (file != null)
            {
                string path = "wwwroot/File/" + file.FileName;

                await file.CopyToAsync(new FileStream(path, FileMode.Create));

                oldData.FilePath = "/File/" + file.FileName;
            }

            oldData.Users = await data.User.Where(x => Users.Contains(x.UserId)).ToListAsync();

            await data.SaveChangesAsync();
        }
    }
}

