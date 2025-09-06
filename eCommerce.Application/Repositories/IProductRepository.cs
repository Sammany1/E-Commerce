using eCommerce.Domain.Models;

namespace eCommerce.Application.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    public Task<IEnumerable<Product>> GetAllProductsByCategory(string categoryName);
    public Task<IEnumerable<Product>> SearchProducts(string searchTerm);
    public Task<IEnumerable<Product>> GetProductsByMerchant(int merchantId);
    public Task<IEnumerable<Product>> GetProductsByMerchantAndCategory(int merchantId, string categoryName);
    public Task<IEnumerable<Product>> SearchProductsByMerchant(int merchantId, string searchTerm);
}
