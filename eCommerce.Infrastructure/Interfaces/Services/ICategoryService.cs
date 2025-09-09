using eCommerce.Infrastructure.DTOs;

namespace eCommerce.Infrastructure.Interfaces.Services;
public interface ICategoryService
{
    public Task<CategoryDto> CreateCategory(string categoryName);
}
