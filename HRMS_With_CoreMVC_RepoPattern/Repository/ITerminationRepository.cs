using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ITerminationRepository
    {
        Task<string> AddTermination(Termination t);

        Task<List<Termination>> GetTerminations();

        Task<string> UpdateTermination(Termination t);

        Task<Termination?> GetTerminationById(int id);

        Task<string> DeleteTermination(int id);
    }
}