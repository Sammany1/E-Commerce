using eCommerce.Application.DTOs;
using eCommerce.Domain.Models;

namespace eCommerce.Application.Services;

public interface IMerchantService
{
    public Task<MerchantDto> GetMerchantByMerchantName(string merchantName);

    public Task<MerchantDto> Create(string merchantName, int adminId);
    public Task<IEnumerable<MerchantDto>> SearchMerchantsByName(string searchTerm);
    public Task<IEnumerable<CategoryDto>> GetMerchantCategories(int merchantId);
}
