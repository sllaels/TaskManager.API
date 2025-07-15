using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.ServiceInterfaces;
using TaskManager.Application.Services;
using TaskManager.Contracts;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.AspNetCore.Authorization;

namespace TaskManager.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskEntityService taskEntityService;
        public TaskController(ITaskEntityService taskEntityService)
        {
          this.taskEntityService = taskEntityService;
        }

        [HttpPost("createTask")]
        public async Task<IActionResult> CreateTaskAsync(TaskRequest request)
        {
          await taskEntityService.CreateTask(request);
            return Ok();
        }
        [HttpGet("prioritetTask")]
        public async Task<IActionResult> GetPrioritetTaskAsync()
        {
            var getTaskByPrioritet = await taskEntityService.GetPrioritetTask();
            return Ok(getTaskByPrioritet);
        }
        [HttpGet("GetTasksByDate")]
        public async Task<IActionResult> GetTaskByDate()
        {
            var getTasksByDate = await taskEntityService.GetByDateTask();
            return Ok(getTasksByDate);
        }
    }
}

