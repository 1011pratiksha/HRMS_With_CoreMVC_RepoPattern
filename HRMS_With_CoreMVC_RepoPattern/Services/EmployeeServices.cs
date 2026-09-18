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
            var departments = await db.Departments.ToListAsync();
            foreach (var department in departments)
            {
                department.NoOfEmployee = await db.User.CountAsync(u => u.DepartmentId == department.DepartmentId);
            }
            return departments;
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
                existingDepartment.Name = department.Name;
                existingDepartment.Status = department.Status;
                existingDepartment.ModifiedBy = "Admin";
                existingDepartment.ModifiedAt = DateTime.Now;
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


        ///---- all add designation page related operational services 
        public async Task<List<Designation>> GetAllDesignations()
        {
            var designations = await db.Designations.ToListAsync();
            foreach (var designation in designations)
            {
                designation.NoOfEmployee = await db.User.CountAsync(u => u.DesignationId == designation.DesignationId);
            }
            return designations;
        }




        public async Task<Designation> GetDesignationById(int id)
        {
            return await db.Designations.FindAsync(id);
        }

        public async Task<Designation> AddDesignation(Designation designation)
        {
            designation.CreatedAt = DateTime.Now;
            db.Designations.Add(designation);
            await db.SaveChangesAsync();
            return designation;
        }

        public async Task<Designation> EditDesignation(Designation designation)
        {
            var existingDesignation = await db.Designations.FindAsync(designation.DesignationId);
            if (existingDesignation != null)
            {
                existingDesignation.Name = designation.Name;
                existingDesignation.status = designation.status;
                existingDesignation.ModifiedBy = "Admin";
                existingDesignation.ModifiedAt = DateTime.Now;
                await db.SaveChangesAsync();
            }
            return existingDesignation;
        }

        public async Task<Designation> DeleteDesignation(int id)
        {
            var designation = await db.Designations.FindAsync(id);
            if (designation != null)
            {
                db.Designations.Remove(designation);
                await db.SaveChangesAsync();
            }
            return designation;
        }


        
        //----Employee list related operations are here

        public async Task<List<User>> GetAllEmployees()
        {
            var employees = await db.User
                .Include(x => x.Role)
                .Include(x => x.Designation)
                .Include(x => x.Department)
                .ToListAsync();

            return employees;
        }

        public async Task<User> GetEmployeeById(int id)
        {
            var emp = await db.User
                .Include(x => x.Role)
                .Include(x => x.Designation)
                .Include(x => x.Department)
                .SingleOrDefaultAsync(x => x.UserId == id);

            return emp;
        }

        public async Task<User> AddEmployee(User user)
        {
            await db.User.AddAsync(user);
            await db.SaveChangesAsync();

            return user;
        }

        public async Task<User> EditEmployee(User user)
        {
            db.User.Update(user);
            await db.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteEmployeeById(int id)
        {
            var data = await db.User
                .SingleOrDefaultAsync(x => x.UserId == id);

            if (data == null)
            {
                return false;
            }

            db.User.Remove(data);
            await db.SaveChangesAsync();

            return true;
        }
    }
}


