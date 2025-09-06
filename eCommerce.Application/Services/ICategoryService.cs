using eCommerce.Application.DTOs;

namespace eCommerce.Application.Services;

public interface ICategoryService
{
    public Task<CategoryDto> CreateCategory(string categoryName);
}
