using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class PayslipReportController : Controller
    {
        private readonly IPayslipReportRepository payslipReportRepository;

        public PayslipReportController(
            IPayslipReportRepository payslipReportRepository)
        {
            this.payslipReportRepository = payslipReportRepository;
        }

        public async Task<IActionResult> Index()
        {
            var payslipReports =
                await payslipReportRepository.fetchPayslipReports();

            ViewBag.TotalPayslips =
                await payslipReportRepository.fetchTotalPayslips();

            ViewBag.TotalPayroll =
                await payslipReportRepository.fetchTotalPayroll();

            ViewBag.TotalNetPay =
                await payslipReportRepository.fetchTotalNetPay();

            return View(payslipReports);
        }
    }
}