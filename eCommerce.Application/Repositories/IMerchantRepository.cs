using eCommerce.Domain.Models;

namespace eCommerce.Application.Repositories;

public interface IMerchantRepository : IBaseRepository<Merchant>
{
    public Task<Merchant> GetMerchantByMerchantName(string merchantName);
    public Task<bool> MerchantNameExist(string merchantName);
}
