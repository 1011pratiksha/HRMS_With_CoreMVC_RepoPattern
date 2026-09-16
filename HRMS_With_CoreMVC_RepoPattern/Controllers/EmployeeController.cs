using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService roleService;
        public EmployeeController(IEmployeeService roleService)
        {
            this.roleService = roleService;
        }
        public IActionResult Index()
        {
            return View();
        }
        // for add role  aal the role related functionality will be here
        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            var roles = await roleService.GetAllRoles();
            return View(roles);
        }

        //----For fetching all roles
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await roleService.GetAllRoles();
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
                var addedRole = await roleService.AddRole(role);
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
            var role = await roleService.GetRoleById(id);
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
                var updatedRole = await roleService.EditRole(role);
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
            var role = await roleService.GetRoleById(id);
            if (role != null)
            {
                await roleService.DeleteRole(id);
            }
            return RedirectToAction("AddRole");
        }

        //for employee list all the employee related functionality will be here
        public IActionResult EmployeeList()
        {
            return View();
        }
        public IActionResult AddDepartment()
        {
            return View();
        }

        public IActionResult AddDesignation()
        {
            return View();
        }
        public IActionResult EmployeeGrid()
        {
            return View();
        }
        public IActionResult EmployeeDetails()
        {
            return View();
        }

    }
}
