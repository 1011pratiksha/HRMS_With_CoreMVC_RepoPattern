using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class LeaveReportServices : ILeaveReportRepository
    {
        private readonly ApplicationDbContext context;

        public LeaveReportServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> fetchTotalLeaves()
        {
            return await context.LeaveRequests.CountAsync();
        }

        public async Task<int> fetchApprovedLeaves()
        {
            return await context.LeaveRequests
                .Where(x => x.Status == "Approved")
                .CountAsync();
        }

        public async Task<int> fetchPendingLeaves()
        {
            return await context.LeaveRequests
                .Where(x => x.Status == "Pending")
                .CountAsync();
        }

        public async Task<int> fetchRejectedLeaves()
        {
            return await context.LeaveRequests
                .Where(x => x.Status == "Rejected")
                .CountAsync();
        }

        public async Task<IEnumerable<LeaveReport>> fetchLeaveReports()
        {
            var leaves = await context.LeaveRequests
                .Select(x => new LeaveReport
                {
                    LeaveRequestId = x.LeaveRequestId,

                    ProfilePicture = x.User.ProfilePicture,

                    UserName = x.User.FirstName + " " + x.User.LastName,

                    LeaveType = x.MasterLeaveType.LeaveType,

                    StartDate = x.StartDate,

                    EndDate = x.EndDate,

                    Status = x.Status,

                    NumberOfDays = x.NumberOfDays,

                    Reason = x.Reason,

                    ApprovedBy = x.ApprovedBy,

                    StatusHistory = x.StatusHistory
                })
                .ToListAsync();

            return leaves;
        }
    }
} 