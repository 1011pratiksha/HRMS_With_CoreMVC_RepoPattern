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
            return View(await _service.FetchAll());
        }

        [HttpPost]
        public async Task<IActionResult> Add(int UserId, List<string> DocName, List<IFormFile> Files)
        {
            for(int i = 0; i < DocName.Count; i++)
            {
                var fileUpload = new FileUpload
                {
                    UserId = UserId,
                    FileName = DocName[i]
                };
                IFormFile file = (Files != null && Files.Count > i) ? Files[i] : null;
                await _service.Add(fileUpload, file);
            }
            TempData["Message"] = "Files uploaded successfully";
            return RedirectToAction("AdminFileUpload");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            string mess = await _service.Delete(id);
            TempData["Message"] = mess;
            return RedirectToAction("AdminFileUpload");
        }
    }
}

    
