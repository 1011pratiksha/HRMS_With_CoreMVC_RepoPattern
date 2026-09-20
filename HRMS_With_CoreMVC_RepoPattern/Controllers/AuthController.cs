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
        public async Task<IActionResult> SignUp(User us)
        {
            if (ModelState.IsValid)
            {
                await authService.SignUp(us);

                TempData["Success"] = "User Registered Successfully";

                return RedirectToAction("SignIn");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(string Email, string Password)
        {
            var role = await authService.SignIn(Email, Password);

            if (role == "Admin" || role == "Manager" || role == "Employee")
            {
                var user = await authService.GetUserByEmail(Email);

                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("Role", role);
            }
            if (role == "Admin")
            {
                HttpContext.Session.SetString("UserRole", "Admin");

                return RedirectToAction("AdminDashboard", "Dashboard");
            }

            if (role == "Manager")
            {
                HttpContext.Session.SetString("UserRole", "Manager");

                return RedirectToAction("ManagerDashboard", "Dashboard");
            }

            if (role == "Employee")
            {
                HttpContext.Session.SetString("UserRole", "Employee");

                return RedirectToAction("EmployeeDashboard", "Dashboard");
            }

            TempData["Error"] = "Invalid Email or Password";

            return RedirectToAction("SignIn");
        }
    }
}