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
        public async Task<IActionResult> AddLeaveType()
        {
            var leaveTypes = await leaveService.GetLeaveTypes();
            return View(leaveTypes);
        }

        [HttpPost]
        public async Task<IActionResult> AddLeaveType(string LeaveType)
        {
            if (string.IsNullOrWhiteSpace(LeaveType))
            {
                TempData["error"] = "Leave type cannot be empty!";
                return RedirectToAction("AddLeaveType");
            }

            if (await leaveService.LeaveTypeExists(LeaveType))
            {
                TempData["error"] = "Leave type already exists!";
                return RedirectToAction("AddLeaveType");
            }

            var newLeaveType = new MasterLeaveType
            {
                LeaveType = LeaveType,
                Status = "Active"
            };

            await leaveService.AddLeaveType(newLeaveType);
            TempData["success"] = "Leave type added successfully!";
            return RedirectToAction("AddLeaveType");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLeaveType(int leaveTypeId)
        {
            var leaveType = await leaveService.GetLeaveTypeById(leaveTypeId);

            if (leaveType == null)
            {
                TempData["error"] = "Leave type not found.";
                return RedirectToAction("AddLeaveType");
            }

            try
            {
                await leaveService.DeleteLeaveType(leaveType);
                TempData["success"] = "Leave type deleted successfully!";
            }
            catch
            {
                TempData["error"] = "Cannot delete this leave type because it is being used in another record.";
            }

            return RedirectToAction("AddLeaveType");
        }

        [HttpGet]
        public async Task<IActionResult> ManageLeaveSettings()
        {
            var leaveSettings = await leaveService.GetLeaveSettings();
            return View(leaveSettings);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLeaveTypeStatus(int leaveTypeId, string status)
        {
            await leaveService.UpdateLeaveTypeStatus(leaveTypeId, status);
            TempData["success"] = "Leave type status updated successfully!";
            return RedirectToAction("ManageLeaveSettings");
        }

        [HttpGet]
        public async Task<IActionResult> AddLeaveDeptwise()
        {
            ViewBag.Departments = new SelectList(await leaveService.GetDepartments(), "DepartmentId", "Name");
            ViewBag.LeaveTypes = new SelectList(await leaveService.GetActiveLeaveTypes(), "LeaveTypeId", "LeaveType");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddLeaveDeptwise(int departmentId, int leaveTypeId, int leavesCount)
        {
            await leaveService.AllocateLeave(departmentId, leaveTypeId, leavesCount);
            TempData["success"] = "Leave allocation for the department has been updated successfully!";
            return RedirectToAction("AddLeaveDeptwise");
        }

        [HttpGet]
        public async Task<IActionResult> DepartmentLeaveDetails()
        {
            ViewBag.Departments = new SelectList(await leaveService.GetDepartments(), "DepartmentId", "Name");
            var departmentLeaves = await leaveService.GetDepartmentLeaveDetails();
            return View(departmentLeaves);
        }

        [HttpPost]
        public async Task<IActionResult> DepartmentLeaveDetails(int departmentId)
        {
            ViewBag.Departments = new SelectList(await leaveService.GetDepartments(), "DepartmentId", "Name");
            var departmentLeaves = await leaveService.GetDepartmentLeaveDetails(departmentId);
            return View(departmentLeaves);
        }

        [HttpGet]
        public async Task<IActionResult> ApplyLeave()
        {
            int userId = 6;
            var leaveDetails = await leaveService.GetEmployeeLeaveDetails(userId);
            return View(leaveDetails);
        }

        [HttpPost]
        public async Task<IActionResult> ApplyLeave(int LeaveTypeId, DateTime StartDate, DateTime EndDate, string Reason)
        {
            int userId = 6;

            if (EndDate < StartDate)
            {
                TempData["error"] = "End date cannot be before start date.";
                return RedirectToAction("ApplyLeave");
            }

            int numberOfDays = (EndDate - StartDate).Days + 1;
            var leaveDetails = await leaveService.GetEmployeeLeaveDetails(userId);
            var leave = leaveDetails.FirstOrDefault(x => x.LeaveTypeId == LeaveTypeId);

            if (leave == null)
            {
                TempData["error"] = "Leave type is not available.";
                return RedirectToAction("ApplyLeave");
            }

            int remainingLeaves = leave.TotalLeaves - leave.UsedLeaves;

            if (numberOfDays > remainingLeaves)
            {
                TempData["error"] = "You do not have enough remaining leaves.";
                return RedirectToAction("ApplyLeave");
            }

            var leaveRequest = new LeaveRequest
            {
                UserId = userId,
                LeaveTypeId = LeaveTypeId,
                StartDate = StartDate,
                EndDate = EndDate,
                NumberOfDays = numberOfDays,
                Reason = Reason,
                Status = "Pending",
                ApprovedBy = "",
                StatusHistory = "Pending"
            };

            await leaveService.ApplyLeave(leaveRequest);
            TempData["success"] = "Leave applied successfully!";
            return RedirectToAction("ApplyLeave");
        }

        [HttpGet]
        public async Task<IActionResult> ViewLeaveRequests()
        {
            var leaveRequests = await leaveService.GetAllLeaveRequests();
            return View(leaveRequests);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLeaveRequest(int LeaveRequestId, string action)
        {
            await leaveService.UpdateLeaveRequest(LeaveRequestId, action);
            TempData["success"] = "Leave request updated successfully!";
            return RedirectToAction("ViewLeaveRequests");
        }

        [HttpGet]
        public async Task<IActionResult> ViewMyLeaveRequests()
        {
            int userId = 6;
            var leaveRequests = await leaveService.GetMyLeaveRequests(userId);
            ViewBag.leaves = await leaveService.GetEmployeeLeaveDetails(userId);
            return View(leaveRequests);
        }
    }
}