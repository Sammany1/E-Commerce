using eCommerce.Application.Repositories;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public class MerchantRepository(eCommerceDbContext context) : BaseRepository<Merchant>(context), IMerchantRepository
{
    private readonly DbSet<Merchant> _merchant = context.Set<Merchant>();
    public async Task<Merchant> GetMerchantByMerchantName(string merchantName)
    {
        return await _merchant.FirstOrDefaultAsync(m => m.MerchantName.ToLower() == merchantName.ToLower());
    }

    public async Task<bool> MerchantNameExist(string merchantName)
    {
        return await _merchant.AnyAsync(m => m.MerchantName.ToLower() == merchantName.ToLower());
    }
}
