using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;

using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class AddRoleService : IAddRoleService
    {
        private readonly ApplicationDbContext db;
        public AddRoleService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Role> AddRole(Role role)
        {
            role.CreatedAt = DateTime.Now;
            db.Role.Add(role);
            await db.SaveChangesAsync();
            return role;
        }

        public async Task<Role> DeleteRole(int id)
        {
            var role = db.Role.Find(id);
            if (role != null)
            {
                db.Role.Remove(role);
                await db.SaveChangesAsync();
            }
            return role;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await db.Role.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await db.Role.FindAsync(id);
        }

        public async Task<Role> UpdateRole(Role role)
        {
            var existingRole = await db.Role.FindAsync(role.RoleId);
            if (existingRole != null)
            {
                // Update properties of existingRole with values from role
                db.Entry(existingRole).CurrentValues.SetValues(role);
                await db.SaveChangesAsync();
            }
            return existingRole;
        }
    }
}
