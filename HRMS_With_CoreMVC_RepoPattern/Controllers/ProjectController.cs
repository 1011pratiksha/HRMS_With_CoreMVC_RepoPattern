
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

        public async Task<IActionResult> Index(string Status, string sort)
        {
            var project = await service.GetProjects();

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

        public async Task<IActionResult> AddProject()
        {
            ViewBag.GetUsers = await service.getUser();

            ViewBag.Managername = await service.GetManagers();

            return View();

        }

        public async Task<IActionResult> ProjectAdd(Projects pro,IFormFile logo,IFormFile file,int[] Users)
        {
            await service.AddProject(pro, logo, file, Users);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> delete(int id)
        {
            await service.DeleteProject(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var getid = await service.GetById(id);

            ViewBag.GetUsers = await service.getUser();

            ViewBag.Managername = await service.GetManagers();

            return View(getid);
        }

        public async Task<IActionResult> upProject(Projects pro,IFormFile logo,IFormFile file,int[] Users)
        {
            await service.UpdateProject(pro, logo, file, Users);

            return RedirectToAction("Index");
        }


        //Now start the Card Section


        public async Task<IActionResult> Card(string Status, string sort)
        {
            var project = await service.GetProjects();

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
