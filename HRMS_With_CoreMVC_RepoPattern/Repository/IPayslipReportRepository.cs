using HRMS_With_CoreMVC_RepoPattern.Models;

namespace HRMS_With_CoreMVC_RepoPattern.Repository
{
    public interface IPayslipReportRepository
    {
        Task<int> fetchTotalPayslips();

        Task<decimal> fetchTotalPayroll();

        Task<decimal> fetchTotalNetPay();

        Task<IEnumerable<PayslipReport>> fetchPayslipReports();

        Task<Dictionary<int, decimal>> fetchSalaryChartData();
    }
}