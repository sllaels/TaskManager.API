using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Interfaces;
using TaskManager.Application.ServiceInterfaces;
using TaskManager.Contracts;
using TaskManager.Domain;
namespace TaskManager.Application.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategory category;
        public CategoryService(ICategory category)
            { this.category = category; }

        public async Task CreateCaterogyAsync(CategoryRequest request)
        {
            Category categoryList = new Category { Tittle = request.Tittle };
            await category.AddAsync(categoryList);
            await category.SaveChangesAsync();
        }
    }
}
