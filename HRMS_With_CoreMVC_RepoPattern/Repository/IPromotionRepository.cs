using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IPromotionRepository
    {
        List<Promotion> FetchGetAll();
        Promotion GetById(int id);
        string Add(Promotion p);
        string Update(Promotion p);
        string Delete(int id);
        List<User> FetchAllUsers();
        List<Designation> FetchAllDesignations();
    }
}
