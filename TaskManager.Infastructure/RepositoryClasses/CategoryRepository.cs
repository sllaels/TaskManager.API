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
    public class CategoryRepository:ICategory
    {
        private readonly AppContextClass contextClass;
        public CategoryRepository(AppContextClass contextClass)
        {
            this.contextClass = contextClass;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()=>await contextClass.Categories.ToListAsync();
        public async Task AddAsync(Category category)=>await contextClass.Categories.AddAsync(category);  

        public void UpDate(Category category)=>contextClass.Categories.Update(category);
        public void Delete(Category category)=>contextClass.Categories.Remove(category);

        public async Task<Category?> GetByIdAsync(int id)=>await contextClass.Categories.FindAsync(id);
        public async Task SaveChangesAsync()=>await contextClass.SaveChangesAsync();
    }
}

