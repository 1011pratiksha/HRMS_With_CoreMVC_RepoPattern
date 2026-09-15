using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IAddRoleService roleService;
        public EmployeeController(IAddRoleService roleService)
        {
            this.roleService = roleService;
        }
        public IActionResult Index()
        {
            return View();
        }
        // for add role  aal the role related functionality will be here
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
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
                var addedRole = await roleService.AddRole(role);
                return Json(new { success = true, message = "Role added successfully.", data = addedRole });
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
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(Role role)
        {
            if (ModelState.IsValid)
            {
                role.ModifiedBy = "Admin"; 
                var updatedRole = await roleService.UpdateRole(role);
                return Json(new { success = true, message = "Role updated successfully.", data = updatedRole });
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, message = "Validation failed.", errors });
            }
        }

        //---for deleting a role
        [HttpPost]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var deletedRole = await roleService.DeleteRole(id);
            if (deletedRole == null)
            {
                return Json(new { success = false, message = "Role not found." });
            }
            return Json(new { success = true, message = "Role deleted successfully.", data = deletedRole });
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
