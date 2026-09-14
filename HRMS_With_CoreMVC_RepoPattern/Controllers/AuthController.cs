using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using HRMS_With_CoreMVC_RepoPattern.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User us)
        {
            if (ModelState.IsValid)
            {
                authService.SignUp(us);

                TempData["Success"] = "User Registered Successfully";

                return RedirectToAction("SignIn");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult SignIn(string Email, string Password)
        {
            var role = authService.SignIn(Email, Password);

            if (role == "Admin")
            {
                return RedirectToAction("AdminDashboard", "Dashboard");
            }

            if (role == "Manager")
            {
                return RedirectToAction("ManagerDashboard", "Dashboard");
            }

            if (role == "Employee")
            {
                return RedirectToAction("EmployeeDashboard", "Dashboard");
            }

            TempData["Error"] = "Invalid Email or Password";

            return RedirectToAction("SignIn");
        }
    }
}