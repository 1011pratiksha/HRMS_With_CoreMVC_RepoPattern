using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ITaskService
    {

<<<<<<< HEAD
=======

>>>>>>> b12580a6a9b953de2065979d94a5387c77fc28a1
        public void AddTask(Tasks tk, IFormFile file, int[] Users);

        public List<Projects> GetProject();

        public List<User> GetUsers(int ProjectId);

        public List<Tasks> GetTask();
<<<<<<< HEAD
=======

        //public List<Tasks> AddTask(Tasks tk, IFormFile file, int[] Users);
>>>>>>> b12580a6a9b953de2065979d94a5387c77fc28a1

    }
}
