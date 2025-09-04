using eCommerce.Domain.Models;

namespace eCommerce.Application.Services;

public interface IMerchantService
{
    public Task<MerchantDto> GetMerchantByMerchantName(string merchantName);
}
