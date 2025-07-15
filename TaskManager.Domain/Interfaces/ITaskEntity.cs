using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManager.Domain.Interfaces
{
public interface ITaskEntity:IGenericRepository<TaskEntity>
    {
        Task<TaskEntity?> GetByCategoryAsync(string category);
        Task<List<TaskEntity>> GetByPrioritet(int id);
        Task<List<TaskEntity>> GetByDate(int userId);
        Task<List<TaskEntity>> GetTasksByIdAsync(int userId);
    }
}
