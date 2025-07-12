using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain;

namespace TaskManager.Infastructure.RepositoryClasses
{
    public class TaskEntityRepository : ITaskEntity
    {
        private readonly AppContextClass contextClass;

        public TaskEntityRepository(AppContextClass contextClass)
        {
            this.contextClass = contextClass;
        }

        private User user=new User();
        public async Task<IEnumerable<TaskEntity>> GetAllAsync()=>await contextClass.Tasks.ToListAsync();

        public async Task AddAsync(TaskEntity task)=>await contextClass.Tasks.AddAsync(task);

        public void UpDate(TaskEntity task)=>contextClass.Tasks.Update(task);

        public void Delete(TaskEntity task)=>contextClass.Tasks.Remove(task);

        public async Task<TaskEntity?> GetByIdAsync(int id)=>await contextClass.Tasks.FindAsync(id);
        public async Task<List<TaskEntity>> GetByPrioritet(string email) => await contextClass.Tasks.Where(u=>user.Email==email).OrderBy(t=>t.Prioritet).ToListAsync();
        public async Task<List<TaskEntity>> GetByDate()=>await contextClass.Tasks.OrderBy(t=>t.Date).ToListAsync();
        public async Task<TaskEntity?> GetByCategoryAsync(string categoryName)=>await contextClass.Tasks.FindAsync(categoryName);

        public async Task SaveChangesAsync()=>await contextClass.SaveChangesAsync();
          
          
    }
}
