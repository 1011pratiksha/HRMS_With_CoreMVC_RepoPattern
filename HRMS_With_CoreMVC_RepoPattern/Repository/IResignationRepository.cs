using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IResignationRepository
    {
        Task<string> AddResignation(Resignation r);

        Task<List<Resignation>> GetResignations();

        Task<string> UpdateResignation(Resignation r);

        Task<Resignation?> GetResignationById(int id);

        Task<string> DeleteResignation(int id);
    }
}