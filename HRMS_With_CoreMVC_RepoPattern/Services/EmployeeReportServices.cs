using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class EmployeeReportServices : IEmployeeReportRepository
    {
        private readonly ApplicationDbContext context;

        public EmployeeReportServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> fetchAllEmployees()
        {
            return await context.User.CountAsync();
        }

        public async Task<int> fetchActiveEmployees()
        {
            return await context.User
                .Where(x => x.Status == "Active")
                .CountAsync();
        }

        public async Task<int> fetchInactiveEmployees()
        {
            return await context.User
                .Where(x => x.Status == "Inactive")
                .CountAsync();
        }

        public async Task<int> fetchTotalDepartments()
        {
            return await context.Departments.CountAsync();
        }

        public async Task<int> fetchTotalRoles()
        {
            return await context.Role.CountAsync();
        }

        public async Task<IEnumerable<EmployeeReport>> fetchEmployeeReports()
        {
            var employees = await context.User
                .Select(x => new EmployeeReport
                {
                    UserId = x.UserId,
                    Name = x.FirstName + " " + x.LastName,
                    Email = x.Email,
                    Department = x.DepartmentId.ToString(),
                    PhoneNumber = x.PhoneNumber,
                    DateOfJoining = x.DateOfJoining,
                    Status = x.Status,
                    ProfilePicture = x.ProfilePicture
                })
                .ToListAsync();

            return employees;
        }

        public async Task<IEnumerable<EmployeeReport>> sortEmployeeReports(
            string? statusType,
            string? sortType)
        {
            var query = context.User.AsQueryable();

            if (!string.IsNullOrEmpty(statusType))
            {
                query = query.Where(x => x.Status == statusType);
            }

            if (sortType == "Ascending")
            {
                query = query.OrderBy(x => x.DateOfJoining);
            }
            else if (sortType == "Descending")
            {
                query = query.OrderByDescending(x => x.DateOfJoining);
            }

            var employees = await query
                .Select(x => new EmployeeReport
                {
                    UserId = x.UserId,
                    Name = x.FirstName + " " + x.LastName,
                    Email = x.Email,
                    Department = x.DepartmentId.ToString(),
                    PhoneNumber = x.PhoneNumber,
                    DateOfJoining = x.DateOfJoining,
                    Status = x.Status,
                    ProfilePicture = x.ProfilePicture
                })
                .ToListAsync();

            return employees;
        }
    }
}