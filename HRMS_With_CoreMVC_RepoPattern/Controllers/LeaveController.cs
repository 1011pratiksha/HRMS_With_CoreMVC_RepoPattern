using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ILeaveService leaveService;
        public LeaveController(ILeaveService leaveService)
        {
            this.leaveService = leaveService;
        }

        [HttpGet]
        public IActionResult AddLeaveType()
        {
            var leaveTypes = leaveService.GetLeaveTypes();
            return View(leaveTypes);
        }

        [HttpPost]
        public IActionResult AddLeaveType(string LeaveType)
        {
            if (string.IsNullOrWhiteSpace(LeaveType))
            {
                TempData["error"] = "Leave type cannot be empty!";
                return RedirectToAction("AddLeaveType");
            }
            if (leaveService.LeaveTypeExists(LeaveType))
            {
                TempData["error"] = "Leave type already exists!";
                return RedirectToAction("AddLeaveType");
            }
            var newLeaveType = new MasterLeaveType
            {
                LeaveType = LeaveType,
                Status = "Active"
            };
            leaveService.AddLeaveType(newLeaveType);
            TempData["success"] = "Leave type added successfully!";
            return RedirectToAction("AddLeaveType");
        }

        [HttpPost]
        public IActionResult DeleteLeaveType(int leaveTypeId)
        {
            var leaveType = leaveService.GetLeaveTypeById(leaveTypeId);
            if (leaveType == null)
            {
                TempData["error"] = "Leave type not found.";
                return RedirectToAction("AddLeaveType");
            }
            try
            {
                leaveService.DeleteLeaveType(leaveType);
                TempData["success"] = "Leave type deleted successfully!";
            }
            catch
            {
                TempData["error"] = "Cannot delete this leave type because it is being used in another record.";
            }
            return RedirectToAction("AddLeaveType");
        }

        [HttpGet]
        public IActionResult ManageLeaveSettings()
        {
            var leaveSettings = leaveService.GetLeaveSettings();
            return View(leaveSettings);
        }

        [HttpPost]
        public IActionResult UpdateLeaveTypeStatus(int leaveTypeId, string status)
        {
            leaveService.UpdateLeaveTypeStatus(leaveTypeId, status);
            TempData["success"] = "Leave type status updated successfully!";
            return RedirectToAction("ManageLeaveSettings");
        }
        [HttpGet]
        public IActionResult AddLeaveDeptwise()
        {
            ViewBag.Departments = new SelectList(leaveService.GetDepartments(), "DepartmentId", "Name");
            ViewBag.LeaveTypes = new SelectList(leaveService.GetActiveLeaveTypes(), "LeaveTypeId", "LeaveType");
            return View();
        }

        [HttpPost]
        public IActionResult AddLeaveDeptwise(int departmentId, int leaveTypeId, int leavesCount)
        {
            leaveService.AllocateLeave(departmentId, leaveTypeId, leavesCount);
            TempData["success"] = "Leave allocation for the department has been updated successfully!";
            return RedirectToAction("AddLeaveDeptwise");
        }

        [HttpGet]
        public IActionResult DepartmentLeaveDetails()
        {
            ViewBag.Departments = new SelectList(leaveService.GetDepartments(), "DepartmentId", "Name");
            var departmentLeaves = leaveService.GetDepartmentLeaveDetails();
            return View(departmentLeaves);
        }

        [HttpPost]
        public IActionResult DepartmentLeaveDetails(int departmentId)
        {
            ViewBag.Departments = new SelectList(leaveService.GetDepartments(), "DepartmentId", "Name");
            var departmentLeaves = leaveService.GetDepartmentLeaveDetails(departmentId);
            return View(departmentLeaves);
        }
    }
}