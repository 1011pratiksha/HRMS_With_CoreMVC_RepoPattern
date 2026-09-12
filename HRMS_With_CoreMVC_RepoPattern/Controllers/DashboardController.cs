using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LogIn()
        {
            string Role = "Admin";  ///Employee/Manager
            if (Role == "Admin")
            {
                return RedirectToAction("AdminDashboard");
            }
            if (Role == "Manager")
            {
                return RedirectToAction("ManagerDashboard");
            }
            if (Role == "Employee")
            {
                return RedirectToAction("EmployeeDashboard");
            }
            else
            {         
                TempData["error"] = "Invalid Role";
                return View();
            }
            
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }
        public IActionResult EmployeeDashboard()
        {
            return View();
        }
        public IActionResult ManagerDashboard()
        {
            return View();
        }
    }
}
