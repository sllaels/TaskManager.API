using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Contracts;
using TaskManager.Domain;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.ServiceInterfaces
{
    public interface ITaskEntityService
    {
        Task CreateTask(TaskRequest request);
        Task<List<TaskEntity>>GetTask();
        Task<List<TaskEntity>> GetPrioritetTask();
        Task<List<TaskEntity>> GetByDateTask();
    }
}
