using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ITerminationRepository
    {
        string AddTermination(Termination t);

        List<Termination> GetTerminations();

        string UpdateTermination(Termination t);

        Termination GetTerminationById(int id);

        string DeleteTermination(int id);
    }
}