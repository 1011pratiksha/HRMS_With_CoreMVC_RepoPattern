using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly IFileUploadRepository _service;

        public FileUploadController(IFileUploadRepository service)
        {
            _service = service;
        }

        public async Task<IActionResult> AdminFileUpload()
        {
            ViewBag.User = await _service.FetchAllUser();
            ViewBag.DocNames = await _service.FetchAllDocNames();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(int UserId, List<string> DocName, List<IFormFile> Files)
        {
            for (int i = 0; i < DocName.Count; i++)
            {
                var model = new FileUpload
                {
                    UserId = UserId,
                    FileName = DocName[i]
                };

                IFormFile file = (Files != null && Files.Count > i) ? Files[i] : null;

                await _service.Add(model, file);
            }

            TempData["Message"] = "Files uploaded successfully!";
            return RedirectToAction("AdminFileUpload");
        }

        public async Task<IActionResult> AdminDocumentList()
        {
            var files = await _service.FetchAll();
            return View(files);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            string message = await _service.Delete(id);
            TempData["Message"] = message;
            return RedirectToAction("AdminDocumentList");
        }

        public async Task<IActionResult> EmployeeFileUpload()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            var user = await _service.FetchUserById(userId.Value);
            ViewBag.CurrentUser = user;
            ViewBag.DocNames = await _service.FetchAllEmployeeDocNames();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeAdd(List<string> DocName, List<IFormFile> Files)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            for (int i = 0; i < DocName.Count; i++)
            {
                var model = new FileUpload
                {
                    UserId = userId.Value,
                    FileName = DocName[i]
                };

                IFormFile file = (Files != null && Files.Count > i) ? Files[i] : null;

                await _service.Add(model, file);
            }

            TempData["Message"] = "Files uploaded successfully!";
            return RedirectToAction("EmployeeFileUpload");
        }

        public async Task<IActionResult> EmployeeDocumentList()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Auth");
            }

            var files = await _service.FetchUserById(userId.Value);
            return View(files);
        }
    }
}

    
