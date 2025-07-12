using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.ServiceInterfaces;
using TaskManager.Application.Services;
using TaskManager.Contracts;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace TaskManager.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskEntity taskEntity;
        public TaskController(ITaskEntity taskEntity)
        {
            this.taskEntity = taskEntity;
        }
        private User user = new User();
        [HttpPost("createTask")]
        public async Task<IActionResult> CreateTaskAsync([FromBody] TaskEntity task)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await taskEntity.AddAsync(task);
            await taskEntity.SaveChangesAsync();
            return Ok(task);

        }
        [HttpGet("prioritetTask")]
        public async Task<IActionResult> GetPrioritetTaskAsync()
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var priorTask=await taskEntity.GetByPrioritet(user.Email);
            return Ok(priorTask);

        }
        [HttpGet("GetTaskByDate")]
        public async Task<IActionResult> GetTaskByDate()
        {
            var dateTask= await taskEntity.GetByDate();
            return Ok(dateTask);
        }
    }
}

