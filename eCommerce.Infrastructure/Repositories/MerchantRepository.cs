using eCommerce.Infrastructure.Interfaces.Repositories;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public class MerchantRepository(eCommerceDbContext context) : BaseRepository<Merchant>(context), IMerchantRepository
{
    private readonly DbSet<Merchant> _merchant = context.Set<Merchant>();
    private readonly DbSet<Product> _product = context.Set<Product>();

    public async Task<bool> MerchantExists(int merchantId)
    {
        return await _merchant.AnyAsync(m => m.Id == merchantId);
    }

    public async Task<Merchant> GetMerchantByName(string merchantName)
    {
        return await _merchant.FirstOrDefaultAsync(m => m.Name.ToLower() == merchantName.ToLower());
    }

    public async Task<bool> MerchantNameExist(string merchantName)
    {
        return await _merchant.AnyAsync(m => m.Name.ToLower() == merchantName.ToLower());
    }

    public async Task<IEnumerable<Merchant>> GetMerchantsByAdminId(int adminId)
    {

        return await _merchant.Where(m => m.AdminId == adminId).ToListAsync();
    }
    
    public async Task<IEnumerable<Merchant>> SearchMerchantsByName(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await _merchant.ToListAsync();

        return await _merchant.Where(m => m.Name.ToLower().Contains(searchTerm.ToLower())).ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetMerchantCategories(int merchantId)
    {
        Merchant merchant = await GetById(merchantId);
        if (merchant == null)
            return Enumerable.Empty<Category>();
        
        return await _product
            .Where(p => p.MerchantId == merchant.Id)
            .Include(p => p.Category)
            .Select(p => p.Category)
            .Distinct()
            .ToListAsync();
    }
}
