using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Interfaces;
using TaskManager.Application.ServiceInterfaces;
using TaskManager.Contracts;
using TaskManager.Domain;
using Microsoft.AspNetCore.Http;
namespace TaskManager.Application.Services
{
    public class CategoryService: WorkWithCurrentUser, ICategoryService
    {
        private readonly ICategory category;
        public CategoryService(ICategory category, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        { this.category = category; }

        public async Task CreateCaterogyAsync(CategoryRequest request)
        {
            var userId=GetCurrentUserId();
            Category categoryList = new Category 
            { Tittle = request.Tittle,
              UserId=userId};
            await category.AddAsync(categoryList);
            await category.SaveChangesAsync();
        }
    }
}
