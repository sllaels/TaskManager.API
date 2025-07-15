using TaskManager.Domain.Interfaces;
using TaskManager.Contracts;
using TaskManager.Application.ServiceInterfaces;
using TaskManager.Domain;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace TaskManager.Application.Services
{
    public class TaskEntityService:WorkWithCurrentUser, ITaskEntityService
    {
        private readonly ITaskEntity taskEntity;
      
        private readonly ILogger<TaskEntityService> logger;
        public TaskEntityService(ITaskEntity taskEntity,ILogger<TaskEntityService> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.taskEntity = taskEntity;

            this.logger = logger;
        }
        public async Task CreateTask(TaskRequest request)
        {
            try
            {
                var userId = GetCurrentUserId();
                TaskEntity task = new TaskEntity
                {
                    Tittle = request.Tittle,
                    Descriptoin = request.Descriptoin,
                    Date = request.Date,
                    Category = request.Category,
                    Prioritet = request.Prioritet,
                    UserId = userId,
                };
                await taskEntity.AddAsync(task);
                await taskEntity.SaveChangesAsync();
     
            }
            catch (UnauthorizedAccessException ex)
            {
                logger.LogWarning(ex, "Пользователь неавторизован при создании задачи");
                throw;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Ошибка при создании задачи");
                throw;
            }
        }

        public async Task<List<TaskEntity>> GetTask()
        {
            var userId= GetCurrentUserId();
            return await taskEntity.GetTasksByIdAsync(userId);
        }
        public async Task<List<TaskEntity>> GetByDateTask()
        {
            var userId = GetCurrentUserId();
            return await taskEntity.GetByDate(userId);
        }
        public async Task<List<TaskEntity>> GetPrioritetTask()
        {
            var userId = GetCurrentUserId();
            var taskWithPrioritet = await taskEntity.GetByPrioritet(userId);
            return taskWithPrioritet;
        }
    }
 
}
