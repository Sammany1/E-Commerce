using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Domain.Models;

namespace eCommerce.Infrastructure.Services;

public class MerchantService : IMerchantService
{
    private readonly IMerchantRepository _merchant;
    public MerchantService(IMerchantRepository merchant)
    {
        _merchant = merchant;
    }
    public async Task<MerchantDto> GetMerchantByMerchantName(string merchantName)
    {
        if (string.IsNullOrWhiteSpace(merchantName))
            return null;
        Merchant merchant = await _merchant.GetMerchantByMerchantName(merchantName);
        if (merchant == null)
            return null;
        MerchantDto merchantDto = new MerchantDto(merchant);
        return merchantDto;
    }

}
