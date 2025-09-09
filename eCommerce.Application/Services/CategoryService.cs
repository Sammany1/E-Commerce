using eCommerce.Infrastructure.DTOs;
using eCommerce.Infrastructure.Interfaces.Repositories;
using eCommerce.Infrastructure.Interfaces.Services;
using eCommerce.Domain.Models;
using Microsoft.Identity.Client;

namespace eCommerce.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _category;
    public CategoryService(ICategoryRepository category)
    {
        _category = category;
    }

    public async Task<CategoryDto> CreateCategory(string categoryName)
    {
        var categoryNameExist = await _category.CategoryNameExists(categoryName);
        if (categoryNameExist)
            return null;
        var category = new Category(categoryName);
        await _category.Create(category);
        return new CategoryDto(category);
    }
}
