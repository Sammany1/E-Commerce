using eCommerce.Application.DTOs;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Domain.Models;
using Microsoft.Identity.Client;

namespace eCommerce.Infrastructure.Services;

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
