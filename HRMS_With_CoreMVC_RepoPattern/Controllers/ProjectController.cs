using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class ProjectController : Controller
    {
        public readonly IProjectService service;
        public ProjectController(IProjectService project) 
        {
            service  = project;   
        }

        public IActionResult Index()
        {
            var project = service.GetProjects();
            return View(project);
        }

        public IActionResult AddProject()
        {
            ViewBag.GetUsers = service.getUser();

            ViewBag.Managername = service.GetManagers();

            return View();

        }

        public IActionResult ProjectAdd(Projects pro, IFormFile logo, IFormFile file, int[] Users)
        {
            service.AddProject(pro, logo, file, Users);

            return RedirectToAction("Index");
        }

        public IActionResult delete(int id)
        {
            service.DeleteProject(id);

            return RedirectToAction("Index");
        }

    }
}
