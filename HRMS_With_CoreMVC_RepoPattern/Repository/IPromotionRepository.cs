using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IPromotionRepository
    {
        Task<List<Promotion>> FetchGetAll();
        Task<Promotion> GetById(int id);
        Task<string> Add(Promotion p);
        Task<string> Update(Promotion p);
        Task<string> Delete(int id);
        Task<List<User>> FetchAllUsers();
        Task<List<Designation>> FetchAllDesignations();
    }
}
