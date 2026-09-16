using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class EmployeeReportController : Controller
    {
        private readonly IEmployeeReportRepository employeeRepository;

        public EmployeeReportController(
            IEmployeeReportRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await employeeRepository.fetchEmployeeReports();

            ViewBag.TotalEmployees = await employeeRepository.fetchAllEmployees();
            ViewBag.ActiveEmployees = await employeeRepository.fetchActiveEmployees();
            ViewBag.InactiveEmployees = await employeeRepository.fetchInactiveEmployees();
            ViewBag.TotalDepartments = await employeeRepository.fetchTotalDepartments();
            ViewBag.TotalRoles = await employeeRepository.fetchTotalRoles();

            return View(employees);
        }
    }
}