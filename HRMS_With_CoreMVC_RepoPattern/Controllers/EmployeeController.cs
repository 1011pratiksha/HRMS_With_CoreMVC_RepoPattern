using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using HRMS_With_CoreMVC_RepoPattern.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService EmployeeServices;
        public EmployeeController(IEmployeeService EmployeeServices)
        {
            this.EmployeeServices = EmployeeServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        // for add role  aal the role related functionality will be here
        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            var roles = await EmployeeServices.GetAllRoles();
            return View(roles);
        }

        //----For fetching all roles
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await EmployeeServices.GetAllRoles();
            var data =roles.Select(r => new
            {
                r.RoleId,
                r.RoleName,
                r.Status,
                CreatedAt = r.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss"),
                r.CreatedBy,
                r.ModifiedBy,
                ModifiedAt = r.ModifiedAt?.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToList();
            return Json(data);
        }

        //-----for adding a new role
        [HttpPost]
        public async Task<IActionResult> AddRole(Role role)
        {
            if (ModelState.IsValid)
            {
                role.CreatedBy = "Admin";
                role.CreatedAt = DateTime.Now;
                var addedRole = await EmployeeServices.AddRole(role);
               return RedirectToAction("AddRole");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, message = "Validation failed.", errors });
            }
        }

        //-------for editing a role
        [HttpGet]
        public async Task<IActionResult> EditRole(int id)
        {
            var role = await EmployeeServices.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            return RedirectToAction("AddRole");
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(Role role)
        {
            if (ModelState.IsValid)
            {
                role.CreatedAt = DateTime.Now;
                role.CreatedBy = "Admin"; 
                var updatedRole = await EmployeeServices.EditRole(role);
                return RedirectToAction("AddRole");  // Redirect to the AddRole view after successful edit
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, message = "Validation failed.", errors });
            }
        }

        //---for deleting a role
        [HttpGet]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await EmployeeServices.GetRoleById(id);
            if (role != null)
            {
                await EmployeeServices  .DeleteRole(id);
            }
            return RedirectToAction("AddRole");
        }

        //for department related functionality will be here
        //
        //

        [HttpGet]
        public async Task<IActionResult> AddDepartment()
        {
            var department = await EmployeeServices.GetAllDepartments();
            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await EmployeeServices.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await EmployeeServices.GetAllDepartments();
            var data = departments.Select(d => new
            {
                d.DepartmentId,
                d.Name,
                d.NoOfEmployee,
                d.Status,
                CreatedAt = d.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss"),
                d.CreatedBy,
                d.ModifiedBy,
                ModifiedAt = d.ModifiedAt?.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToList();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                department.CreatedBy = "Admin";
                department.CreatedAt = DateTime.Now;
                var addedDepartment = await EmployeeServices.AddDepartment(department);
                return RedirectToAction("AddDepartment");
            }
            else
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return Json(new
                {
                    success = false,
                    message = "Validation failed.",
                    errors
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                await EmployeeServices.EditDepartment(department);
                return RedirectToAction("AddDepartment");
            }

            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return Json(new
            {
                success = false,message = "Validation failed.",errors
            });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await EmployeeServices.GetDepartmentById(id);
            if (department != null)
            {
                await EmployeeServices.DeleteDepartment(id);
            }
            return RedirectToAction("AddDepartment");
        }



        //---- all the add designation page related operations are here
        [HttpGet]
        public async Task<IActionResult> AddDesignation()
        {
            var designations = await EmployeeServices.GetAllDesignations();

            ViewBag.Departments = await EmployeeServices.GetAllDepartments();

            return View(designations);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDesignations()
        {
            var designations = await EmployeeServices.GetAllDesignations();
            var data = designations.Select(d => new
            {
                d.DesignationId,
                d.Name,
                d.NoOfEmployee,
                d.status,
                CreatedAt = d.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss"),
                d.CreatedBy,
                d.ModifiedBy,
                ModifiedAt = d.ModifiedAt?.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToList();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetDesignationById(int id)
        {
            var designation = await EmployeeServices.GetDesignationById(id);
            if (designation == null)
            {
                return NotFound();
            }
            return View(designation);
        }
        [HttpPost]
        public async Task<IActionResult> AddDesignation(Designation designation)
        {
            if (ModelState.IsValid)
            {
                designation.CreatedBy = "Admin";
                designation.CreatedAt = DateTime.Now;
                var addedDesignation = await EmployeeServices.AddDesignation(designation);
                return RedirectToAction("AddDesignation");
            }
            else
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return Json(new
                {
                    success = false,
                    message = "Validation failed.",
                    errors
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditDesignation(Designation designation)
        {
            if (ModelState.IsValid)
            {
                await EmployeeServices.EditDesignation(designation);
                return RedirectToAction("AddDesignation");
            }
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return Json(new
            {
                success = false,
                message = "Validation failed.",
                errors
            });
        }
        [HttpGet]

        public async Task<IActionResult> DeleteDesignation(int id)
        {
            var designation = await EmployeeServices.GetDesignationById(id);
            if (designation != null)
            {
                await EmployeeServices.DeleteDesignation(id);
            }
            return RedirectToAction("AddDesignation");
        }



        //for employee list all the employee related functionality will be here

        [HttpGet]
        public async Task<IActionResult> EmployeeList(
    DateTime? startDate,
    DateTime? endDate,
    int? designationId,
    string? status,
    string? sorting)
        {
            var employees = await EmployeeServices.GetAllEmployees(
                startDate,
                endDate,
                designationId,
                status,
                sorting);

            ViewBag.Designations = await EmployeeServices.GetAllDesignations();
            ViewBag.Roles = await EmployeeServices.GetAllRoles();
            ViewBag.Departments = await EmployeeServices.GetAllDepartments();

            // Get all users for Reporting Manager dropdown
            ViewBag.Users = await EmployeeServices.GetAllEmployees(
                null,
                null,
                null,
                null,
                null);

            // Keep selected filter values
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");
            ViewBag.DesignationId = designationId;
            ViewBag.Status = status;
            ViewBag.Sorting = sorting;

            return View(employees);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await EmployeeServices.GetAllEmployees(
                null,
                null,
                null,
                null,
                null);

            ViewBag.Designations = await EmployeeServices.GetAllDesignations();
            ViewBag.Roles = await EmployeeServices.GetAllRoles();
            ViewBag.Departments = await EmployeeServices.GetAllDepartments();

            ViewBag.Users = await EmployeeServices.GetAllEmployees(
                null,
                null,
                null,
                null,
                null);

            return View(employees);
        }

        [HttpGet]

        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await EmployeeServices.GetEmployeeById(id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);

        }

        
        [HttpPost]
        public async Task<IActionResult> AddEmployee(User user, IFormFile? profilePicture)
        {
            if (profilePicture != null && profilePicture.Length > 0)
            {
                string uploadsFolder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "uploads"
                );

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fileName = Guid.NewGuid().ToString()
                    + Path.GetExtension(profilePicture.FileName);

                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await profilePicture.CopyToAsync(stream);
                }

                user.ProfilePicture = "/uploads/" + fileName;
            }
            if (ModelState.IsValid)
            {
                user.CreatedBy = "Admin";
                user.CreatedAt = DateTime.Now;

                var passwordHasher = new PasswordHasher<User>();

                user.PasswordHash = passwordHasher.HashPassword(user, user.PasswordHash);

                var addedEmployee = await EmployeeServices.AddEmployee(user);

                return RedirectToAction("EmployeeList");
            }
            else
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return Json(new
                {
                    success = false,
                    message = "Validation failed.",
                    errors
                });
            }
        }
        [HttpPost]
public async Task<IActionResult> EditEmployee(User user)
{
    // Password is not edited from the Edit Employee modal
    ModelState.Remove("PasswordHash");

    if (ModelState.IsValid)
    {
        await EmployeeServices.EditEmployee(user);

        TempData["Success"] = "Employee updated successfully";

        return RedirectToAction("EmployeeList");
    }

    return RedirectToAction("EmployeeList");
}


        [HttpPost]
        public async Task<IActionResult> DeleteEmployeeById(int id)
        {
            var result = await EmployeeServices.DeleteEmployeeById(id);

            if (!result)
            {
                return NotFound();
            }

            TempData["Success"] = "employee deleted successfully";

            return RedirectToAction("EmployeeList");
        }


       
       

        //-----for employee grid data
        [HttpGet]
        public async Task<IActionResult> EmployeeGrid()
        {
            var employees = await EmployeeServices.GetEmployeeGridData();

            ViewBag.Designations = await EmployeeServices.GetAllDesignations();
            ViewBag.Roles = await EmployeeServices.GetAllRoles();
            ViewBag.Departments = await EmployeeServices.GetAllDepartments();

            ViewBag.Users = await EmployeeServices.GetAllEmployees(
                null,
                null,
                null,
                null,
                null);

            return View(employees);
        }


        //------for employee details page
        [HttpGet]
        public async Task<IActionResult> EmployeeDetails()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            var userProfile = await EmployeeServices.GetUserProfile(userId.Value);

            if (userProfile == null)
            {
                return NotFound();
            }

            var bankDetails = await EmployeeServices.GetBankDetails(userId.Value);
            var familyDetails = await EmployeeServices.GetFamilyDetails(userId.Value);
            var educationDetails = await EmployeeServices.GetEducationDetails(userId.Value);
            var experiences = await EmployeeServices.GetExperiences(userId.Value);

            ViewBag.BankDetails = bankDetails;
            ViewBag.FamilyDetails = familyDetails;
            ViewBag.EducationDetails = educationDetails;
            ViewBag.Experiences = experiences;

            return View(userProfile);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployeeProfile(User user)
        {
            await EmployeeServices.EditEmployeeProfile(user);

            return RedirectToAction("EmployeeDetails");
        }
        [HttpPost]
        public async Task<IActionResult> AddBankDetails(EmployeeBankDetails bankDetails)
        {
            if (ModelState.IsValid)
            {
                await EmployeeServices.AddBankDetails(bankDetails);

                return RedirectToAction("EmployeeDetails");
            }

            return RedirectToAction("EmployeeDetails");
        }


        [HttpPost]
        public async Task<IActionResult> EditBankDetails(EmployeeBankDetails bankDetails)
        {
            if (ModelState.IsValid)
            {
                await EmployeeServices.EditBankDetails(bankDetails);

                return RedirectToAction("EmployeeDetails");
            }

            return RedirectToAction("EmployeeDetails");
        }

        [HttpPost]
        public async Task<IActionResult> AddFamilyDetails(EmployeeFamilyDetail familyDetails)
        {
            await EmployeeServices.AddFamilyDetails(familyDetails);

            return RedirectToAction("EmployeeDetails");
        }

        [HttpPost]
        public async Task<IActionResult> EditFamilyDetails(EmployeeFamilyDetail familyDetails)
        {
            await EmployeeServices.EditFamilyDetails(familyDetails);

            return RedirectToAction("EmployeeDetails");
        }

        [HttpPost]
        public async Task<IActionResult> AddEducationDetails(EducationDetails educationDetails)
        {
            await EmployeeServices.AddEducationDetails(educationDetails);

            return RedirectToAction("EmployeeDetails");
        }

        [HttpPost]
        public async Task<IActionResult> EditEducationDetails(EducationDetails educationDetails)
        {
            await EmployeeServices.EditEducationDetails(educationDetails);

            return RedirectToAction("EmployeeDetails");
        }

        [HttpPost]
        public async Task<IActionResult> AddExperience(Experience experience)
        {
            await EmployeeServices.AddExperience(experience);

            return RedirectToAction("EmployeeDetails");
        }

        [HttpPost]
        public async Task<IActionResult> EditExperience(Experience experience)
        {
            await EmployeeServices.EditExperience(experience);

            return RedirectToAction("EmployeeDetails");
        }
    }
}
