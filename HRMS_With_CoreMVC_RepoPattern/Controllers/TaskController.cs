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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTask()
        {
            return View();
        }
    }
}
