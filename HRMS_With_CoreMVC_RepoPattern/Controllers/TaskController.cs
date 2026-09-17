using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService service;
        public TaskController(ITaskService task)
        {
            service = task;
        }
        public IActionResult Index(string priority)
        {

            var task = service.GetTask();


            if(priority == "High")
            {
                task = task.Where(x => x.Priority == "High").ToList();
            }

            if (priority == "Medium")
            {
                task = task.Where(x => x.Priority == "Medium").ToList();
            }

            if (priority == "Low")
            {
                task = task.Where(x => x.Priority == "Low").ToList();
            }


            return View(task);
        }


        public IActionResult AddTask(int projectId)
        {
            ViewBag.GetProject = service.GetProject();
            ViewBag.GetUser = service.GetUsers(projectId);

            ViewBag.ProjectId = projectId;

            return View();
        }

        [HttpPost]
        public IActionResult AddProjectForm(Tasks tk, IFormFile file, int[] Users)
        {

            service.AddTask(tk, file, Users);
            return RedirectToAction("Index");
        }

       

    }
}
