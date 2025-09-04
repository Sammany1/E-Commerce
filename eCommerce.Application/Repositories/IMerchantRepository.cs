using eCommerce.Domain.Models;

namespace eCommerce.Application.Repositories;

public interface IMerchantRepository
{
    public Task<Merchant> GetMerchantByMerchantName(string merchantName);

}
