using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ITaskService
    {

        public void AddTask(Tasks tk, IFormFile file, int[] Users);

        public List<Projects> GetProject();

        public List<User> GetUsers(int ProjectId);

        public List<Tasks> GetTask();

    }
}
