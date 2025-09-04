using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.DTOs;
using eCommerce.Domain.Models;
using System.Reflection.Metadata.Ecma335;

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
        Merchant merchant = await _merchant.GetMerchantByName(merchantName);
        if (merchant == null)
            return null;
        MerchantDto merchantDto = new MerchantDto(merchant);
        return merchantDto;
    }


    public async Task<MerchantDto> Create(string merchantName, int adminId)
    {
        if (string.IsNullOrWhiteSpace(merchantName))
            return null;
        if (await _merchant.MerchantNameExist(merchantName))
            return null;

        Merchant merchant = new Merchant(merchantName, adminId);
        await _merchant.Create(merchant);
        MerchantDto merchantDto = new MerchantDto(merchant);
        return merchantDto;
    }

    public async Task<IEnumerable<MerchantDto>> SearchMerchantsByName(string searchTerm)
    {
        var merchants = await _merchant.SearchMerchantsByName(searchTerm);
        return merchants.Select(m => new MerchantDto(m)).ToList();
    }
}
