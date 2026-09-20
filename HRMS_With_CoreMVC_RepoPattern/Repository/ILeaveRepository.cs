using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ILeaveService
    {
        Task<List<MasterLeaveType>> GetLeaveTypes();
        Task<bool> LeaveTypeExists(string leaveType);
        Task AddLeaveType(MasterLeaveType leaveType);
        Task<MasterLeaveType> GetLeaveTypeById(int leaveTypeId);
        Task DeleteLeaveType(MasterLeaveType leaveType);
        Task<List<MasterLeaveType>> GetLeaveSettings();
        Task UpdateLeaveTypeStatus(int leaveTypeId, string status);
        Task<List<Department>> GetDepartments();
        Task<List<MasterLeaveType>> GetActiveLeaveTypes();
        Task AllocateLeave(int departmentId, int leaveTypeId, int leavesCount);
        Task<List<DepartmentLeaves>> GetDepartmentLeaveDetails();
        Task<List<DepartmentLeaves>> GetDepartmentLeaveDetails(int departmentId);
        Task<List<LeaveBalance>> GetEmployeeLeaveDetails(int userId);
        Task ApplyLeave(LeaveRequest leaveRequest);
        Task<List<LeaveRequest>> GetMyLeaveRequests(int userId);
        Task<List<LeaveRequest>> GetAllLeaveRequests();
        Task UpdateLeaveRequest(int leaveRequestId, string action);
    }
}