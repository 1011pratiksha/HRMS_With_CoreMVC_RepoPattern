using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ITrainerRepository
    {
        Task<List<Trainer>> FetchAll();
        Task<Trainer> FetchById(int id);
        Task<string> Add(Trainer t);
        Task<string> Update(Trainer t);
        Task<string> Delete(int id);
        Task<List<Role>> FetchAllRoles();
    }
}
