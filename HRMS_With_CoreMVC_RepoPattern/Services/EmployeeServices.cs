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

        public async Task<List<User>> GetAllEmployees(
    DateTime? startDate,
    DateTime? endDate,
    int? designationId,
    string? status,
    string? sorting)
        {
            var employees = db.User
                .Include(x => x.Role)
                .Include(x => x.Designation)
                .Include(x => x.Department)
                .AsQueryable();

            // Start Date
            if (startDate.HasValue)
            {
                employees = employees.Where(x =>
                    x.DateOfJoining >= startDate.Value);
            }

            // End Date
            if (endDate.HasValue)
            {
                employees = employees.Where(x =>
                    x.DateOfJoining <= endDate.Value);
            }

            // Designation
            if (designationId.HasValue)
            {
                employees = employees.Where(x =>
                    x.DesignationId == designationId.Value);
            }

            // Status
            if (!string.IsNullOrEmpty(status))
            {
                employees = employees.Where(x =>
                    x.Status == status);
            }

            // Sorting
            if (sorting == "NameAsc")
            {
                employees = employees
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName);
            }
            else if (sorting == "NameDesc")
            {
                employees = employees
                    .OrderByDescending(x => x.FirstName)
                    .ThenByDescending(x => x.LastName);
            }
            else if (sorting == "Newest")
            {
                employees = employees
                    .OrderByDescending(x => x.DateOfJoining);
            }
            else if (sorting == "Oldest")
            {
                employees = employees
                    .OrderBy(x => x.DateOfJoining);
            }

            return await employees.ToListAsync();
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
            var existingUser = await db.User.FindAsync(user.UserId);

            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.Status = user.Status;

                existingUser.ModifiedBy = "Admin";
                existingUser.ModifiedAt = DateTime.Now;

                await db.SaveChangesAsync();
            }

            return existingUser;
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

        //----for employee grid data
       
public async Task<List<EmployeeGridViewModel>> GetEmployeeGridData()
        {
            var employees = await db.User
                .Include(x => x.Designation)
                .ToListAsync();

            var result = new List<EmployeeGridViewModel>();

            foreach (var employee in employees)
            {
                // Get tasks assigned to this employee
                var taskMembers = await db.Taskmember
                    .Include(x => x.Task)
                    .Where(x => x.UserId == employee.UserId)
                    .ToListAsync();

                // Total projects assigned through tasks
                var totalProjects = taskMembers
                    .Where(x => x.Task != null)
                    .Select(x => x.Task.ProjectId)
                    .Distinct()
                    .Count();

                // Completed tasks
                var completedTasks = taskMembers
                    .Count(x => x.Task != null &&
                                x.Task.Status == "Completed");

                // In Progress tasks
                var inProgressTasks = taskMembers
                    .Count(x => x.Task != null &&
                                x.Task.Status == "In Progress");

                // Pending tasks
                var pendingTasks = taskMembers
                    .Count(x => x.Task != null &&
                                x.Task.Status == "Pending");

                // Get employee timesheets
                var timesheets = await db.Timesheets
<<<<<<< HEAD
                    .Where(x => x.UserId == employee.UserId)
                    .ToListAsync();
=======
       .Where(x => x.UserId == employee.UserId)
       .ToListAsync();
>>>>>>> 13eb8bcf39b62071f77bfee233aaa9c4afc36a8e

                // Productivity
                // 8 working hours per recorded day = 100%
                var totalWorkHours = timesheets.Sum(x => x.WorkHours);

                var workingDays = timesheets
                    .Select(x => x.Date.Date)
                    .Distinct()
                    .Count();

                int productivity = 0;

                if (workingDays > 0)
                {
                    var expectedHours = workingDays * 8;

                    productivity = (int)Math.Round(
                        ((double)totalWorkHours / expectedHours) * 100
                    );

                    // Do not show more than 100%
                    if (productivity > 100)
                    {
                        productivity = 100;
                    }
                }

                result.Add(new EmployeeGridViewModel
                {
                    UserId = employee.UserId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    ProfilePicture = employee.ProfilePicture,
                    DesignationName = employee.Designation?.Name,
                    TotalProjects = totalProjects,
                    CompletedTasks = completedTasks,
                    InProgressTasks = inProgressTasks,
                    PendingTasks = pendingTasks,
                    Productivity = productivity,
                    Status = employee.Status
                });
            }

            return result;
        }

        //-----for employeedetails means user profile page

        public async Task<User> GetUserProfile(int userId)
        {
            return await db.User
                .Include(x => x.Role)
                .Include(x => x.Designation)
                .Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.UserId == userId);
        }
        public async Task<User> EditEmployeeProfile(User user)
        {
            var existingUser = await db.User
                .FirstOrDefaultAsync(x => x.UserId == user.UserId);

            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.DateOfJoining = user.DateOfJoining;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.Gender = user.Gender;
                existingUser.Address = user.Address;
                existingUser.AboutEmployee = user.AboutEmployee;
                existingUser.ProfilePicture = user.ProfilePicture;
                existingUser.ReportingManager = user.ReportingManager;
                existingUser.ModifiedAt = DateTime.Now;

                await db.SaveChangesAsync();
            }

            return existingUser;
        }

        public async Task<EmployeeBankDetails> GetBankDetails(int userId)
        {
            return await db.EmployeeBankDetails
                .FirstOrDefaultAsync(x => x.UserId == userId);
        }
        public async Task<EmployeeBankDetails> AddBankDetails(EmployeeBankDetails bankDetails)
        {
            db.EmployeeBankDetails.Add(bankDetails);
            await db.SaveChangesAsync();

            return bankDetails;
        }

        public async Task<EmployeeBankDetails> EditBankDetails(EmployeeBankDetails bankDetails)
        {
            db.EmployeeBankDetails.Update(bankDetails);
            await db.SaveChangesAsync();

            return bankDetails;
        }
        public async Task<List<EmployeeFamilyDetail>> GetFamilyDetails(int userId)
        {
            return await db.EmployeeFamilyDetails
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
        public async Task<EmployeeFamilyDetail> AddFamilyDetails(EmployeeFamilyDetail familyDetails)
        {
            db.EmployeeFamilyDetails.Add(familyDetails);
            await db.SaveChangesAsync();

            return familyDetails;
        }

        public async Task<EmployeeFamilyDetail> EditFamilyDetails(EmployeeFamilyDetail familyDetails)
        {
            var existingFamily = await db.EmployeeFamilyDetails
                .FirstOrDefaultAsync(x => x.FamilyDetailId == familyDetails.FamilyDetailId);

            if (existingFamily != null)
            {
                existingFamily.Name = familyDetails.Name;
                existingFamily.Relation = familyDetails.Relation;
                existingFamily.DateOfBirth = familyDetails.DateOfBirth;
                existingFamily.phone = familyDetails.phone;

                await db.SaveChangesAsync();
            }

            return existingFamily;
        }

        public async Task<List<EducationDetails>> GetEducationDetails(int userId)
        {
            return await db.EducationDetails
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
        public async Task<EducationDetails> AddEducationDetails(EducationDetails educationDetails)
        {
            db.EducationDetails.Add(educationDetails);
            await db.SaveChangesAsync();

            return educationDetails;
        }

        public async Task<EducationDetails> EditEducationDetails(EducationDetails educationDetails)
        {
            var existingEducation = await db.EducationDetails
                .FirstOrDefaultAsync(x => x.EducationDetailsId == educationDetails.EducationDetailsId);

            if (existingEducation != null)
            {
                existingEducation.EducationType = educationDetails.EducationType;
                existingEducation.UniversityName = educationDetails.UniversityName;
                existingEducation.startdate = educationDetails.startdate;
                existingEducation.enddate = educationDetails.enddate;

                await db.SaveChangesAsync();
            }

            return existingEducation;
        }

        public async Task<List<Experience>> GetExperiences(int userId)
        {
            return await db.Experiences
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<Experience> AddExperience(Experience experience)
        {
            db.Experiences.Add(experience);
            await db.SaveChangesAsync();

            return experience;
        }

        public async Task<Experience> EditExperience(Experience experience)
        {
            var existingExperience = await db.Experiences
                .FirstOrDefaultAsync(x => x.ExperienceId == experience.ExperienceId);

            if (existingExperience != null)
            {
                existingExperience.CompanyName = experience.CompanyName;
                existingExperience.DesignationName = experience.DesignationName;
                existingExperience.FromDate = experience.FromDate;
                existingExperience.ToDate = experience.ToDate;

                await db.SaveChangesAsync();
            }

            return existingExperience;
        }


    }
}


