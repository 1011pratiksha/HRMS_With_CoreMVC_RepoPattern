
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

        public async Task<IActionResult> Index(string priority)
        {
            var task = await service.GetTask();

            if (priority == "High")
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


        public async Task<IActionResult> AddTask(int projectId)
        {
            ViewBag.GetProject = await service.GetProject();
            ViewBag.GetUser = await service.GetUsers(projectId);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTaskForm(Tasks tk, IFormFile file, int[] Users)
        {
            await service.AddTask(tk, file, Users);

            return RedirectToAction("Index");
        }
    }
}
