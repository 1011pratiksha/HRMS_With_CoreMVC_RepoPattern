using HRMS_With_CoreMVC_RepoPattern.Models;
using Microsoft.AspNetCore.Http;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IProjectService
    {
        public void AddProject(Projects pro, IFormFile logo, IFormFile file, int[] Users);

        public List<User> getUser();

        public List<User> GetManagers();

        public List<Projects> GetProjects();

        public void DeleteProject(int id);

        public Projects GetById(int id);
        public void UpdateProject(Projects pro, IFormFile logo, IFormFile file, int[] Users);
    }
}
