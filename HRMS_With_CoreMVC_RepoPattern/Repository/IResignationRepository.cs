using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IResignationRepository
    {
        string AddResignation(Resignation r);
        List<Resignation> GetResignations();
        string UpdateResignation(Resignation r);

        Resignation GetResignationById(int id);
        string DeleteResignation(int id);
    }
}
