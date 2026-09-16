using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class PayslipReportServices : IPayslipReportRepository
    {
        private readonly ApplicationDbContext context;

        public PayslipReportServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> fetchTotalPayslips()
        {
            return await context.Payslips.CountAsync();
        }

        public async Task<decimal> fetchTotalPayroll()
        {
            return await context.EmployeeSalaries
                .SumAsync(x => x.TotalSalary);
        }

        public async Task<decimal> fetchTotalNetPay()
        {
            return await context.EmployeeSalaries
                .SumAsync(x => x.NetSalary);
        }

        public async Task<IEnumerable<PayslipReport>> fetchPayslipReports()
        {
            var payslips = await context.Payslips
                .Select(x => new PayslipReport
                {
                    PayslipId = x.PayslipId,

                    UserName = x.User.FirstName + " " + x.User.LastName,

                    Designation = x.User.Designation.Name,

                    ProfilePicture = x.User.ProfilePicture,

                    PaidAmount = context.EmployeeSalaries
                        .Where(s => s.UserId == x.UserId)
                        .OrderByDescending(s => s.CreatedDate)
                        .Select(s => s.NetSalary)
                        .FirstOrDefault(),

                    PaidMonth = x.Month,

                    PaidYear = x.Year
                })
                .ToListAsync();

            return payslips;
        }
    }
}