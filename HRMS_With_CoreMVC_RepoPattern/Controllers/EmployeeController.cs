using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using HRMS_With_CoreMVC_RepoPattern.Services;
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
       
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await EmployeeServices.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
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
        //public async Task<IActionResult> AddDesignation()
        //{
        //    var designations = await EmployeeServices.GetAllDesignations();
        //    return View(designations);
        //}

    //    public async Task<IActionResult> GetAllDesignations()
    //    {
    //        var designations = await EmployeeServices.GetAllDesignations();
    //        var data = designations.Select(d => new
    //        {
    //            d.DesignationId,
    //            d.Name,
    //            d.NoOfEmployee,
    //            d.status,
    //            CreatedAt = d.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss"),
    //            d.CreatedBy,
    //            d.ModifiedBy,
    //            ModifiedAt = d.ModifiedAt?.ToString("yyyy-MM-dd HH:mm:ss")
    //        }).ToList();
    //        return View(data);
    //    }

    //    public async Task<IActionResult> GetDesignationById(int id)
    //    {
    //        var designation = await EmployeeServices.GetDesignationById(id);
    //        if (designation == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(designation);
    //    }

    //    public async Task<IActionResult> AddDesignation(Designation designation)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            designation.CreatedBy = "Admin";
    //            designation.CreatedAt = DateTime.Now;
    //            var addedDesignation = await EmployeeServices.AddDesignation(designation);
    //            return RedirectToAction("AddDesignation");
    //        }
    //        else
    //        {
    //            var errors = ModelState.Values
    //                .SelectMany(v => v.Errors)
    //                .Select(e => e.ErrorMessage)
    //                .ToList();
    //            return Json(new
    //            {
    //                success = false,
    //                message = "Validation failed.",
    //                errors
    //            });
    //        }
    //    }

    //    public async Task<IActionResult> EditDesignation(Designation designation)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            await EmployeeServices.EditDesignation(designation);
    //            return RedirectToAction("AddDesignation");
    //        }
    //        var errors = ModelState.Values
    //            .SelectMany(v => v.Errors)
    //            .Select(e => e.ErrorMessage)
    //            .ToList();
    //        return Json(new
    //        {
    //            success = false,
    //            message = "Validation failed.",
    //            errors
    //        });
    //    }

    //    public async Task<IActionResult> DeleteDesignation(int id)
    //    {
    //        var designation = await EmployeeServices.GetDesignationById(id);
    //        if (designation != null)
    //        {
    //            await EmployeeServices.DeleteDesignation(id);
    //        }
    //        return RedirectToAction("AddDesignation");
    //    }



    //    //for employee list all the employee related functionality will be here

    //    public IActionResult EmployeeList()
    //    {
    //        return View();
    //    }
    //    public IActionResult EmployeeGrid()
    //    {
    //        return View();
    //    }
    //    public IActionResult EmployeeDetails()
    //    {
    //        return View();
    //    }

    }
}
