using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IAddRoleService
    {
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRoleById(int id);

        Task<Role> AddRole(Role role);
        Task<Role> UpdateRole(Role role); 
        Task<Role> DeleteRole(int id);
    }
}
