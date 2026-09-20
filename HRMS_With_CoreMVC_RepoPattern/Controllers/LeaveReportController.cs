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
            var leaveReports = (await leaveReportRepository.fetchLeaveReports()).ToList();

            ViewBag.TotalLeaves = await leaveReportRepository.fetchTotalLeaves();
            ViewBag.ApprovedLeaves = await leaveReportRepository.fetchApprovedLeaves();
            ViewBag.PendingLeaves = await leaveReportRepository.fetchPendingLeaves();
            ViewBag.RejectedLeaves = await leaveReportRepository.fetchRejectedLeaves();

            DateTime today = DateTime.Today;
            DateTime currentMonthStart = new DateTime(today.Year, today.Month, 1);
            DateTime lastMonthStart = currentMonthStart.AddMonths(-1);
            DateTime currentMonthEnd = currentMonthStart.AddMonths(1);
            DateTime lastMonthEnd = currentMonthStart;

            var currentMonthLeaves = leaveReports.Where(x => x.StartDate >= currentMonthStart && x.StartDate < currentMonthEnd).ToList();
            var lastMonthLeaves = leaveReports.Where(x => x.StartDate >= lastMonthStart && x.StartDate < lastMonthEnd).ToList();

            int currentTotal = currentMonthLeaves.Count;
            int lastTotal = lastMonthLeaves.Count;

            int currentApproved = currentMonthLeaves.Count(x => x.Status == "Approved");
            int lastApproved = lastMonthLeaves.Count(x => x.Status == "Approved");

            int currentPending = currentMonthLeaves.Count(x => x.Status == "Pending");
            int lastPending = lastMonthLeaves.Count(x => x.Status == "Pending");

            int currentRejected = currentMonthLeaves.Count(x => x.Status == "Rejected");
            int lastRejected = lastMonthLeaves.Count(x => x.Status == "Rejected");

            ViewBag.TotalLeavePercentage = lastTotal == 0 ? 0 : ((double)(currentTotal - lastTotal) / lastTotal) * 100;
            ViewBag.ApprovedLeavePercentage = lastApproved == 0 ? 0 : ((double)(currentApproved - lastApproved) / lastApproved) * 100;
            ViewBag.PendingLeavePercentage = lastPending == 0 ? 0 : ((double)(currentPending - lastPending) / lastPending) * 100;
            ViewBag.RejectedLeavePercentage = lastRejected == 0 ? 0 : ((double)(currentRejected - lastRejected) / lastRejected) * 100;

            return View(leaveReports);
        }
    }
}