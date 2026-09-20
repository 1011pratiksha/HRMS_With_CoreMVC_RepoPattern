
using HRMS_With_CoreMVC_RepoPattern.Models;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS_With_CoreMVC_RepoPattern.Controllers
{
    public class TaskBoardController : Controller
    {
        private readonly ITaskBoardService service;

        public TaskBoardController(ITaskBoardService taskBoardService)
        {
            service = taskBoardService;
        }


        public async Task<IActionResult> Index(string priority)
        {
            var projectData = await service.GetProjectsWithTasks();

            foreach (var project in projectData)
            {
                if (priority != null)
                {
                    project.Task = project.Task.Where(x => x.Priority == priority).ToList();
                }
            }

            return View(projectData);
        }

        public async Task<IActionResult> AddTaskBoard(int projectId)
        {
            ViewBag.GetProject = await service.GetProject();

            ViewBag.GetTask = await service.GetTasks(projectId);

            return View();
        }

        public async Task<IActionResult> AddTask(TaskBoards task)
        {
            await service.AddTkBoard(task);

            return RedirectToAction("Index");
        }
    }
}
