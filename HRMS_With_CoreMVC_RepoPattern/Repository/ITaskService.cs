
using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ITaskService
    {
        public Task AddTask(Tasks tk, IFormFile file, int[] Users);

        public Task<List<Projects>> GetProject();

        public Task<List<User>> GetUsers(int ProjectId);

        public Task<List<Tasks>> GetTask();
    }
}
