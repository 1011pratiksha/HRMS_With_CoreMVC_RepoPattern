using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ITrainerRepository
    {
        List<Trainer> FetchAll();
        Trainer GetById(int id);
        string Add(Trainer t);
        string Update(Trainer t);
        string Delete(int id);
        List<Role> FetchAllRoles();
    }
}
