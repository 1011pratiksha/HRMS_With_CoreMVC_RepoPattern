using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;

namespace HRMS_With_CoreMVC_RepoPattern.Services
{
    public class EmployeeReportServices : IEmployeeReportRepository
    {
        private readonly ApplicationDbContext context;
        public  EmployeeReportServices(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<EmployeeReport> FetchAllEmployeeReport()
        {
            throw new NotImplementedException();
        }
    }
}
