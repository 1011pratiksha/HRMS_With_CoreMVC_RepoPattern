using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ITaskBoardService
    {
        public List<Projects> GetProject();

        public List<Tasks> GetTasks(int projectId);

        public void AddTkBoard(TaskBoards task);

        public List<Projects> GetProjectsWithTasks();
    }
}
