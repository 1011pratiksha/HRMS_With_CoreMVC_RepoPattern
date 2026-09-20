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


        public IActionResult Index(string priority)
        {
            var projectData = service.GetProjectsWithTasks();

            foreach (var project in projectData)
            {
                if (priority != null)
                {
                    project.Task = project.Task.Where(x => x.Priority == priority) .ToList();
                }
            }

            return View(projectData);
        }

        public IActionResult AddTaskBoard(int projectId)
        {
            ViewBag.GetProject = service.GetProject();

            ViewBag.GetTask = service.GetTasks(projectId);

            return View();
        }

        public IActionResult AddTask(TaskBoards task)
        {
            service.AddTkBoard(task);

            return RedirectToAction("Index");
        }
    }
}
