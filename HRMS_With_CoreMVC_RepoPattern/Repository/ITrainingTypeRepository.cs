using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ITrainingTypeRepository
    {
        Task<List<TrainingType>> FetchAll();
        Task<TrainingType> FetchById(int id);
        Task <string> Add(TrainingType t);
        Task<string> Update(TrainingType t);
        Task<string> Delete(int id);
    }
}
