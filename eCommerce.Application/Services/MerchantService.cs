using eCommerce.Infrastructure.Interfaces.Repositories;
using eCommerce.Infrastructure.Interfaces.Services;
using eCommerce.Infrastructure.DTOs;
using eCommerce.Domain.Models;
using System.Reflection.Metadata.Ecma335;

namespace eCommerce.Application.Services;

public class MerchantService : IMerchantService
{
    private readonly IMerchantRepository _merchant;
    public MerchantService(IMerchantRepository merchant)
    {
        _merchant = merchant;
    }

    public async Task<IEnumerable<MerchantDto>> GetAllMerchant(int pageNumber = 1, int pageSize = 10)
    {
        var merchants = await _merchant.GetAll();
        return merchants.Select(merchant => new MerchantDto(merchant)).ToList();
    }
    public async Task<IEnumerable<MerchantDto>> GetMerchantsByAdminId(int adminId)
    {
        var merchants = await _merchant.GetMerchantsByAdminId(adminId);
        return merchants.Select(merchant => new MerchantDto(merchant)).ToList();
    }

    public async Task<MerchantDto> GetMerchantById(int merchantId)
    {
        var merchant = await _merchant.GetById(merchantId);
        MerchantDto merchantDto = new MerchantDto(merchant);
        return merchantDto;
    }
    public async Task<MerchantDto> GetMerchantByName(string merchantName)
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

    public async Task<IEnumerable<CategoryDto>> GetMerchantCategories(int merchantId)
    {
        var categories = await _merchant.GetMerchantCategories(merchantId);
        if (categories == Enumerable.Empty<Category>())
            return null;
        return categories.Select(c => new CategoryDto(c)).ToList();
    }

}
