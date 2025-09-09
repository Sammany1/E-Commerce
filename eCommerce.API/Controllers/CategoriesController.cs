using eCommerce.Infrastructure.DTOs;
using eCommerce.Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _category;
        public CategoriesController(ICategoryService category)
        {
            _category = category;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.name))
                return BadRequest();

            var categoryDto = await _category.CreateCategory(request.name);
            if (categoryDto == null)
                return BadRequest("Cateogry Name Already Exist");


            return categoryDto;
        }
    }
}
