using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Net.NetworkInformation;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class ProjectController : Controller
    {
        public readonly IProjectService service;
        public ProjectController(IProjectService project)
        {
            service = project;
        }

        public IActionResult Index(string Status, string sort)
        {
            var project = service.GetProjects();

            if(Status == "Active"){
                project = project.Where(x => x.Status == "Active").ToList();
            }

            else if(Status == "Inactive")
            {
                project = project.Where(x => x.Status == "Inactive").ToList();
            }

            else if (Status == "All")
            {
                project = project.ToList();
            }


            if (sort == "asc")
            {
                project = project.OrderBy(x => x.ProjectId).ToList();
            }

            else if (sort == "desc")
            {
                project = project.OrderByDescending(x => x.ProjectId).ToList();
            }


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

        public IActionResult Edit(int id)
        {
            var getid = service.GetById(id);

            ViewBag.GetUsers = service.getUser();

            ViewBag.Managername = service.GetManagers();
            return View(getid);
        }

        public IActionResult upProject(Projects pro, IFormFile logo, IFormFile file, int[] Users)
        {
            service.UpdateProject(pro, logo, file,Users);

            return RedirectToAction("Index");
        }


        //Now start the Card Section


        public IActionResult Card(string Status, string sort)
        {
            var project = service.GetProjects();

            if (Status == "Active")
            {
                project = project.Where(x => x.Status == "Active").ToList();
            }

            else if (Status == "Inactive")
            {
                project = project.Where(x => x.Status == "Inactive").ToList();
            }

            else if (Status == "All")
            {
                project = project.ToList();
            }


            if (sort == "asc")
            {
                project = project.OrderBy(x => x.ProjectId).ToList();
            }

            else if (sort == "desc")
            {
                project = project.OrderByDescending(x => x.ProjectId).ToList();
            }


            return View(project);
        }


       
    }
}
