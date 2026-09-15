using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;
namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly ApplicationDbContext db;
        public LeaveService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<MasterLeaveType> GetLeaveTypes()
        {
            var data = db.MasterLeaveTypes.ToList();
            return data;
        }
        public bool LeaveTypeExists(string leaveType)
        {
            var data = db.MasterLeaveTypes
                .Any(x => x.LeaveType.ToLower() == leaveType.ToLower());
            return data;
        }
        public void AddLeaveType(MasterLeaveType leaveType)
        {
            db.MasterLeaveTypes.Add(leaveType);
            db.SaveChanges();
        }
        public MasterLeaveType GetLeaveTypeById(int leaveTypeId)
        {
            var data = db.MasterLeaveTypes
                .FirstOrDefault(x => x.LeaveTypeId == leaveTypeId);
            return data;
        }
        public void DeleteLeaveType(MasterLeaveType leaveType)
        {
            db.MasterLeaveTypes.Remove(leaveType);
            db.SaveChanges();
        }
        public List<MasterLeaveType> GetLeaveSettings()
        {
            var data = db.MasterLeaveTypes.ToList();
            return data;
        }
        public void UpdateLeaveTypeStatus(int leaveTypeId, string status)
        {
            var leaveType = db.MasterLeaveTypes
                .FirstOrDefault(x => x.LeaveTypeId == leaveTypeId);
            if (leaveType != null)
            {
                leaveType.Status = status;
                db.SaveChanges();
            }
        }
        public List<Department> GetDepartments()
        {
            var data = db.Departments.ToList();
            return data;
        }
        public List<MasterLeaveType> GetActiveLeaveTypes()
        {
            var data = db.MasterLeaveTypes
                .Where(x => x.Status == "Active")
                .ToList();
            return data;
        }
        public void AllocateLeave(int departmentId, int leaveTypeId, int leavesCount)
        {
            var departmentLeave = db.DepartmentLeaves
                .FirstOrDefault(x =>
                    x.DepartmentId == departmentId &&
                    x.LeaveTypeId == leaveTypeId);
            if (departmentLeave == null)
            {
                departmentLeave = new DepartmentLeaves
                {
                    DepartmentId = departmentId,
                    LeaveTypeId = leaveTypeId,
                    LeavesCount = leavesCount,
                    Status = "Active"
                };
                db.DepartmentLeaves.Add(departmentLeave);
            }
            else
            {
                departmentLeave.LeavesCount += leavesCount;
                db.DepartmentLeaves.Update(departmentLeave);
            }
            db.SaveChanges();
            var employees = db.User
                .Where(x => x.DepartmentId == departmentId)
                .ToList();
            foreach (var employee in employees)
            {
                var leaveBalance = db.LeaveBalances
                    .FirstOrDefault(x =>
                        x.UserId == employee.UserId &&
                        x.LeaveTypeId == leaveTypeId);
                if (leaveBalance == null)
                {
                    leaveBalance = new LeaveBalance
                    {
                        UserId = employee.UserId,
                        DepartmentLeavesId = departmentLeave.DepartmentLeavesId,
                        LeaveTypeId = leaveTypeId,
                        TotalLeaves = leavesCount,
                        UsedLeaves = 0
                    };
                    db.LeaveBalances.Add(leaveBalance);
                }
                else
                {
                    leaveBalance.TotalLeaves += leavesCount;
                    db.LeaveBalances.Update(leaveBalance);
                }
            }
            db.SaveChanges();
        }
        public List<DepartmentLeaves> GetDepartmentLeaveDetails()
        {
            var data = db.DepartmentLeaves
                .Include(x => x.Department)
                .Include(x => x.MasterLeaveType)
                .ToList();
            return data;
        }
        public List<DepartmentLeaves> GetDepartmentLeaveDetails(int departmentId)
        {
            var data = db.DepartmentLeaves
                .Include(x => x.Department)
                .Include(x => x.MasterLeaveType)
                .Where(x => x.DepartmentId == departmentId)
                .ToList();
            return data;
        }
    }
}