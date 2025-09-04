using System.Collections;
using eCommerce.Domain.Models;

namespace eCommerce.Application.Repositories;

public interface IMerchantRepository : IBaseRepository<Merchant>
{
    public Task<Merchant> GetMerchantByName(string merchantName);
    public Task<bool> MerchantNameExist(string merchantName);
    public Task<IEnumerable<Merchant>> SearchMerchantsByName(string searchTerm);
}
