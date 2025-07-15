using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.ServiceInterfaces;
using TaskManager.Contracts;

namespace TaskManager.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController:ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("createCategories")]
        public async Task<IActionResult> CreateCategories(CategoryRequest request)
        {
            await _categoryService.CreateCaterogyAsync(request);
            return Ok();
        }
    }
}
