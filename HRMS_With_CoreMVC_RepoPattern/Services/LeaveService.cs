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
        public async Task<List<MasterLeaveType>> GetLeaveTypes()
        {
            var data = await db.MasterLeaveTypes.ToListAsync();
            return data;
        }
        public async Task<bool> LeaveTypeExists(string leaveType)
        {
            var data = await db.MasterLeaveTypes
                .AnyAsync(x => x.LeaveType.ToLower() == leaveType.ToLower());
            return data;
        }
        public async Task AddLeaveType(MasterLeaveType leaveType)
        {
            db.MasterLeaveTypes.Add(leaveType);
            await db.SaveChangesAsync();
        }
        public async Task<MasterLeaveType> GetLeaveTypeById(int leaveTypeId)
        {
            var data = await db.MasterLeaveTypes
                .FirstOrDefaultAsync(x => x.LeaveTypeId == leaveTypeId);
            return data;
        }
        public async Task DeleteLeaveType(MasterLeaveType leaveType)
        {
            db.MasterLeaveTypes.Remove(leaveType);
            await db.SaveChangesAsync();
        }
        public async Task<List<MasterLeaveType>> GetLeaveSettings()
        {
            var data = await db.MasterLeaveTypes.ToListAsync();
            return data;
        }
        public async Task UpdateLeaveTypeStatus(int leaveTypeId, string status)
        {
            var leaveType = await db.MasterLeaveTypes
                .FirstOrDefaultAsync(x => x.LeaveTypeId == leaveTypeId);
            if (leaveType != null)
            {
                leaveType.Status = status;
                await db.SaveChangesAsync();
            }
        }
        public async Task<List<Department>> GetDepartments()
        {
            var data = await db.Departments.ToListAsync();
            return data;
        }
        public async Task<List<MasterLeaveType>> GetActiveLeaveTypes()
        {
            var data = await db.MasterLeaveTypes
                .Where(x => x.Status == "Active")
                .ToListAsync();
            return data;
        }
        public async Task AllocateLeave(int departmentId, int leaveTypeId, int leavesCount)
        {
            var departmentLeave = await db.DepartmentLeaves
                .FirstOrDefaultAsync(x =>
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
            await db.SaveChangesAsync();
            var employees = await db.User
                .Where(x => x.DepartmentId == departmentId)
                .ToListAsync();
            foreach (var employee in employees)
            {
                var leaveBalance = await db.LeaveBalances
                    .FirstOrDefaultAsync(x =>
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
            await db.SaveChangesAsync();
        }
        public async Task<List<DepartmentLeaves>> GetDepartmentLeaveDetails()
        {
            var data = await db.DepartmentLeaves
                .Include(x => x.Department)
                .Include(x => x.MasterLeaveType)
                .ToListAsync();
            return data;
        }
        public async Task<List<DepartmentLeaves>> GetDepartmentLeaveDetails(int departmentId)
        {
            var data = await db.DepartmentLeaves
                .Include(x => x.Department)
                .Include(x => x.MasterLeaveType)
                .Where(x => x.DepartmentId == departmentId)
                .ToListAsync();
            return data;
        }
        public async Task<List<LeaveBalance>> GetEmployeeLeaveDetails(int userId)
        {
            var data = await db.LeaveBalances
                .Include(x => x.MasterLeaveType)
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return data;
        }
        public async Task ApplyLeave(LeaveRequest leaveRequest)
        {
            db.LeaveRequests.Add(leaveRequest);
            await db.SaveChangesAsync();
        }
        public async Task<List<LeaveRequest>> GetMyLeaveRequests(int userId)
        {
            var data = await db.LeaveRequests
                .Include(x => x.MasterLeaveType)
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return data;
        }
        public async Task<List<LeaveRequest>> GetAllLeaveRequests()
        {
            var data = await db.LeaveRequests
                .Include(x => x.User)
                .Include(x => x.MasterLeaveType)
                .ToListAsync();
            return data;
        }
        public async Task UpdateLeaveRequest(int leaveRequestId, string action)
        {
            var leave = await db.LeaveRequests
                .FirstOrDefaultAsync(x => x.LeaveRequestId == leaveRequestId);
            if (leave != null)
            {
                if (action == "Approve" && leave.Status == "Pending")
                {
                    leave.Status = "Approved";
                    leave.ApprovedBy = "Manager";
                    var leaveBalance = await db.LeaveBalances
                        .FirstOrDefaultAsync(x =>
                            x.UserId == leave.UserId &&
                            x.LeaveTypeId == leave.LeaveTypeId);
                    if (leaveBalance != null)
                    {
                        leaveBalance.UsedLeaves += leave.NumberOfDays;
                    }
                }
                else if (action == "Reject" && leave.Status == "Pending")
                {
                    leave.Status = "Rejected";
                    leave.ApprovedBy = "Manager";
                }
                leave.StatusHistory = leave.Status;
                await db.SaveChangesAsync();
            }
        }
    }
}