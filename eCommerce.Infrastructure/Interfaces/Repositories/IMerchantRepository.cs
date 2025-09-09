using eCommerce.Domain.Models;

namespace eCommerce.Infrastructure.Interfaces.Repositories;
public interface IMerchantRepository : IBaseRepository<Merchant>
{
    public Task<bool> MerchantExists(int merchantId);
    public Task<Merchant> GetMerchantByName(string merchantName);
    public Task<bool> MerchantNameExist(string merchantName);
    public Task<IEnumerable<Merchant>> SearchMerchantsByName(string searchTerm);
    public Task<IEnumerable<Category>> GetMerchantCategories(int merchantId);
}
