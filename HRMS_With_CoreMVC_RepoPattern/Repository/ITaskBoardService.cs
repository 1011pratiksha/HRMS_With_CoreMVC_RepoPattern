
using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ITaskBoardService
    {
        public Task<List<Projects>> GetProject();

        public Task<List<Tasks>> GetTasks(int projectId);

        public Task AddTkBoard(TaskBoards task);

        public Task<List<Projects>> GetProjectsWithTasks();
    }
}
