using eCommerce.Application.Repositories;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public class ProductRepository(eCommerceDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    private readonly DbSet<Product> _product = context.Set<Product>();

    public async Task<IEnumerable<Product>> GetAllProductsByCategory(string categoryName)
    {

        return await _product
            .Where(p => p.Category.Name.ToLower() == categoryName.ToLower())
            .Include(p => p.Category)
            .ToListAsync();
    }
    public async Task<IEnumerable<Product>> SearchProducts(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAll();

        return await _product
            .Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()))
            .Include(p => p.Category)
            .ToListAsync();
    }
    public async Task<IEnumerable<Product>> GetProductsByMerchant(int merchantId)
    {
        return await _product
            .Where(p => p.MerchantId == merchantId)
            .Include(p => p.Merchant)
            .ToListAsync();
    }
    public async Task<IEnumerable<Product>> GetProductsByMerchantAndCategory(int merchantId, string categoryName)
    {
        if (string.IsNullOrWhiteSpace(categoryName))
            return await GetProductsByMerchant(merchantId);

        return await _product
            .Where(p => p.MerchantId == merchantId &&
                        p.Category.Name.ToLower() == categoryName.ToLower())
            .Include(p => p.Category)
            .Include(p => p.Merchant)
            .ToListAsync();
    }
    public async Task<IEnumerable<Product>> SearchProductsByMerchant(int merchantId, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetProductsByMerchant(merchantId);

        return await _product
            .Where(p => p.MerchantId == merchantId &&
                        p.Name.ToLower().Contains(searchTerm.ToLower()))
            .ToListAsync();
    }
}
