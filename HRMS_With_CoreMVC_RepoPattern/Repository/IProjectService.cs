
using HRMS_With_CoreMVC_RepoPattern.Models;
using Microsoft.AspNetCore.Http;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IProjectService
    {
        public Task AddProject(Projects pro, IFormFile logo, IFormFile file, int[] Users);

        public Task<List<User>> getUser();

        public Task<List<User>> GetManagers();

        public Task<List<Projects>> GetProjects();

        public Task DeleteProject(int id);

        public Task<Projects> GetById(int id);

        public Task UpdateProject(Projects pro, IFormFile logo, IFormFile file, int[] Users);
    }
}

