using eCommerce.Application.DTOs;

namespace eCommerce.Application.Services;

public interface IMerchantService
{
    public Task<MerchantDto> GetMerchantByMerchantName(string merchantName);

    public Task<MerchantDto> Create(string merchantName, int adminId);
}
