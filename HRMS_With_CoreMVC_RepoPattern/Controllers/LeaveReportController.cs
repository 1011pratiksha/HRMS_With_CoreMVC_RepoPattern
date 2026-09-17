using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class LeaveReportController : Controller
    {
        private readonly ILeaveReportRepository leaveReportRepository;

        public LeaveReportController(ILeaveReportRepository leaveReportRepository)
        {
            this.leaveReportRepository = leaveReportRepository;
        }

        public async Task<IActionResult> Index()
        {
            // Get leave report records
            var leaveReports = await leaveReportRepository.fetchLeaveReports();

            // Get summary counts
            ViewBag.TotalLeaves = await leaveReportRepository.fetchTotalLeaves();
            ViewBag.ApprovedLeaves = await leaveReportRepository.fetchApprovedLeaves();
            ViewBag.PendingLeaves = await leaveReportRepository.fetchPendingLeaves();
            ViewBag.RejectedLeaves = await leaveReportRepository.fetchRejectedLeaves();

            return View(leaveReports);
        }
    }
}