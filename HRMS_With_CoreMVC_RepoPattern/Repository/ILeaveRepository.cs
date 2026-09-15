using HRMS_With_CoreMVC_RepoPattern.Models;
namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface ILeaveService
    {
        List<MasterLeaveType> GetLeaveTypes();
        bool LeaveTypeExists(string leaveType);
        void AddLeaveType(MasterLeaveType leaveType);
        MasterLeaveType GetLeaveTypeById(int leaveTypeId);
        void DeleteLeaveType(MasterLeaveType leaveType);
        List<MasterLeaveType> GetLeaveSettings();
        void UpdateLeaveTypeStatus(int leaveTypeId, string status);
        List<Department> GetDepartments();
        List<MasterLeaveType> GetActiveLeaveTypes();
        void AllocateLeave(int departmentId, int leaveTypeId, int leavesCount);
        List<DepartmentLeaves> GetDepartmentLeaveDetails();
        List<DepartmentLeaves> GetDepartmentLeaveDetails(int departmentId);
    }
}