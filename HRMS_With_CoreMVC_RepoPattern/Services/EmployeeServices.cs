using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class EmployeeServices : IEmployeeService
    {
        private readonly ApplicationDbContext db;
        public EmployeeServices(ApplicationDbContext db)
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
            var role = db.Role.FirstOrDefault(x => x.RoleId == id);
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

        public async Task<Role> EditRole(Role role)
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


        ///---- all add deparment page related operational services 
        public async Task<List<Department>> GetAllDepartments()
        {
            return await db.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await db.Departments.FindAsync(id);
        }

        public async Task<Department> AddDepartment(Department department)
        {
            department.CreatedAt = DateTime.Now;
            db.Departments.Add(department);
            await db.SaveChangesAsync();
            return department;
        }

        public async Task<Department> EditDepartment(Department department)
        {
            var existingDepartment = await db.Departments.FindAsync(department.DepartmentId);
            if (existingDepartment != null)
            {
                // Update properties of existingDepartment with values from department
                db.Entry(existingDepartment).CurrentValues.SetValues(department);
                await db.SaveChangesAsync();
            }
            return existingDepartment;
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            var department = db.Departments.FirstOrDefault(x => x.DepartmentId == id);
            if (department != null)
            {
                db.Departments.Remove(department);
                await db.SaveChangesAsync();
            }
            return department;
        }
        

       

        
    }
}
