using eCommerce.Infrastructure.DTOs;
using eCommerce.Infrastructure.Interfaces.Repositories;
using eCommerce.Infrastructure.Interfaces.Services;

namespace eCommerce.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _product;
    private readonly IMerchantRepository _merchant;
    private readonly ICategoryRepository _category;
    public ProductService(IProductRepository product, IMerchantRepository merchant, ICategoryRepository category)
    {
        _product = product;
        _merchant = merchant;
        _category = category;
    }

    public async Task<ProductDto> GetProductById(int productId)
    {
        var product = await _product.GetById(productId);
        if (product == null)
            return null;
        var productDto = new ProductDto(product);
        return productDto;
    }
    public async Task<IEnumerable<ProductDto>> GetAllProducts()
    {
        var products = await _product.GetAll();
        return products.Select(p => new ProductDto(p)).ToList();
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsByCategory(string categoryName)
    {
        if (string.IsNullOrWhiteSpace(categoryName))
            return await GetAllProducts();

        var products = await _product.GetAllProductsByCategory(categoryName);
        return products.Select(p => new ProductDto(p)).ToList();
    }

    public async Task<IEnumerable<ProductDto>> SearchProducts(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllProducts();

        var products = await _product.SearchProducts(searchTerm);
        return products.Select(p => new ProductDto(p)).ToList();
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByMerchant(int merchantId)
    {
        if (merchantId <= 0)
            return Enumerable.Empty<ProductDto>();

        var products = await _product.GetProductsByMerchant(merchantId);
        return products.Select(p => new ProductDto(p)).ToList();
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByMerchantAndCategory(int merchantId, string categoryName)
    {
        if (merchantId <= 0)
            return Enumerable.Empty<ProductDto>();

        if (string.IsNullOrWhiteSpace(categoryName))
            return await GetProductsByMerchant(merchantId);

        var products = await _product.GetProductsByMerchantAndCategory(merchantId, categoryName);
        return products.Select(p => new ProductDto(p)).ToList();
    }

    public async Task<IEnumerable<ProductDto>> SearchProductsByMerchant(int merchantId, string searchTerm)
    {
        if (merchantId <= 0)
            return Enumerable.Empty<ProductDto>();

        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetProductsByMerchant(merchantId);

        var products = await _product.SearchProductsByMerchant(merchantId, searchTerm);
        return products.Select(p => new ProductDto(p)).ToList();
    }

    public async Task<ProductDto> CreateProduct(ProductCreateDto productDto)
    {
        if (productDto == null)
            return null;

        var merchantExist = await _merchant.MerchantExists(productDto.MerchantId);
        var categoryExist = await _category.CategoryExists(productDto.CategoryId);
        if (!merchantExist || !categoryExist)
            return null;    

        var product = productDto.MapToProduct();
        
        await _product.Create(product);
        return new ProductDto(product);
    }
    
    public async Task<ProductDto> UpdateProduct(ProductUpdateDto productDto)
    {
        if (productDto == null || productDto.Id <= 0)
            return null;
            
        var existingProduct = await _product.GetById(productDto.Id);
        var categoryExist = await _category.CategoryExists(productDto.CategoryId);
        if (existingProduct == null || !categoryExist)
            return null;
            
        existingProduct = productDto.MapToProduct(existingProduct);
        
        await _product.Update(existingProduct);
        return new ProductDto(existingProduct);
    }
    
    public async Task<bool> DeleteProduct(int id)
    {
        if (id <= 0)
            return false;
            
        var product = await _product.GetById(id);
        if (product == null)
            return false;
            
        await _product.Delete(id);
        return true;
    }
}
