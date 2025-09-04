using eCommerce.Application.Repositories;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public class MerchantRepository(eCommerceDbContext context) : BaseRepository<Merchant>(context), IMerchantRepository
{
    private readonly DbSet<Merchant> _merchant = context.Set<Merchant>();
    public async Task<Merchant> GetMerchantByName(string merchantName)
    {
        return await _merchant.FirstOrDefaultAsync(m => m.MerchantName.ToLower() == merchantName.ToLower());
    }

    public async Task<bool> MerchantNameExist(string merchantName)
    {
        return await _merchant.AnyAsync(m => m.MerchantName.ToLower() == merchantName.ToLower());
    }
    
    public async Task<IEnumerable<Merchant>> SearchMerchantsByName(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await _merchant.ToListAsync();

        return await _merchant.Where(m => m.MerchantName.ToLower().Contains(searchTerm.ToLower())).ToListAsync();
    }
}
