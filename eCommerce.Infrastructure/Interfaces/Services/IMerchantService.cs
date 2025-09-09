using eCommerce.Infrastructure.DTOs;
using eCommerce.Domain.Models;

namespace eCommerce.Infrastructure.Interfaces.Services;
public interface IMerchantService
{
    public Task<MerchantDto> Create(string merchantName, int adminId);
    public Task<MerchantDto> GetMerchantById(int merchantId);
    public Task<MerchantDto> GetMerchantByName(string merchantName);
    public Task<IEnumerable<MerchantDto>> SearchMerchantsByName(string searchTerm);
    public Task<IEnumerable<CategoryDto>> GetMerchantCategories(int merchantId);
}
