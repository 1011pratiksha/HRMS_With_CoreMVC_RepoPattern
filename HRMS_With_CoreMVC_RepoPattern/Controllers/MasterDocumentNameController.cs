using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class MasterDocumentNameController : Controller
    {
        private readonly IFileUploadRepository _service;

        public MasterDocumentNameController(IFileUploadRepository service)
        {
            _service = service;
        }

        public IActionResult AddDocNameAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDocNameAdmin(AddAdminDocName a)
        {
            string message = await _service.AddAdminDocName(a);
            TempData["Message"] = message;
            return RedirectToAction("FetchAdminDocName");
        }

        public IActionResult AddDocNameEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditAdminDocName(AddAdminDocName a)
        {
            string message = await _service.UpdateAdminDocName(a);
            TempData["Message"] = message;
            return RedirectToAction("FetchAdminDocName");
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployeeDocName(AddEmployeeDocName a)
        {
            string message = await _service.UpdateEmployeeDocName(a);
            TempData["Message"] = message;
            return RedirectToAction("FetchEmployeeDocName");
        }

        [HttpPost]
        public async Task<IActionResult> AddDocNameEmployee(AddEmployeeDocName a)
        {
            string message = await _service.AddEmployeeDocName(a);
            TempData["Message"] = message;
            return RedirectToAction("FetchEmployeeDocName");
        }

        public async Task<IActionResult> FetchAdminDocName()
        {
            var list = await _service.FetchAllDocNames();
            return View(list);
        }

        public async Task<IActionResult> FetchEmployeeDocName()
        {
            var list = await _service.FetchAllEmployeeDocNames();
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAdminDocName(int id)
        {
            string message = await _service.DeleteAdminDocName(id);
            TempData["Message"] = message;
            return RedirectToAction("FetchAdminDocName");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployeeDocName(int id)
        {
            string message = await _service.DeleteEmployeeDocName(id);
            TempData["Message"] = message;
            return RedirectToAction("FetchEmployeeDocName");
        }
    }
}
