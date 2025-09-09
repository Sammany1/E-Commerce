using eCommerce.Infrastructure.DTOs;

namespace eCommerce.Infrastructure.Interfaces.Services;
public interface IProductService
{
    public Task<ProductDto> GetProductById(int productId);
    public Task<IEnumerable<ProductDto>> GetAllProducts();
    public Task<IEnumerable<ProductDto>> GetAllProductsByCategory(string categoryName);
    public Task<IEnumerable<ProductDto>> SearchProducts(string searchTerm);
    public Task<IEnumerable<ProductDto>> GetProductsByMerchant(int merchantId);
    public Task<IEnumerable<ProductDto>> GetProductsByMerchantAndCategory(int merchantId, string categoryName);
    public Task<IEnumerable<ProductDto>> SearchProductsByMerchant(int merchantId, string searchTerm);
    public Task<ProductDto> CreateProduct(ProductCreateDto productDto);
    public Task<ProductDto> UpdateProduct(ProductUpdateDto productDto);
    public Task<bool> DeleteProduct(int id);
}
