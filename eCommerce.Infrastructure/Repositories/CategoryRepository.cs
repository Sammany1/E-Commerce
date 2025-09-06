using eCommerce.Application.Repositories;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public class CategoryRepository(eCommerceDbContext context) : BaseRepository<Category>(context), ICategoryRepository
{
    private readonly DbSet<Category> _category = context.Set<Category>();

    public async Task<bool> CategoryExists(int CategoryId)
    {
        return await _category.AnyAsync(c => c.Id == CategoryId);
    }
    public async Task<bool> CategoryNameExists(string categoryName)
    {
        return await _category.AnyAsync(c => c.Name == categoryName);
    }

}
