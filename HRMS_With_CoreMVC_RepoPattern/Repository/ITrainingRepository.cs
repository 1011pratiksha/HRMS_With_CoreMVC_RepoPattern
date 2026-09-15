using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ITrainingRepository
    {
        Task<List<Training>> FetchAll();
        Task<Training> FetchById(int id);
        Task<string> Add(Training t, string createdBy);
        Task<string> Update(Training t);
        Task<string> Delete(int id);
        Task<List<Trainer>> FetchAllTrainers();
        Task<List<TrainingType>> FetchAllTrainingTypes();
        Task<List<User>> FetchAllUsers();
    }
}
