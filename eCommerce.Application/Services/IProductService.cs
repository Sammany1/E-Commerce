using eCommerce.Application.DTOs;
using eCommerce.Domain.Models;

namespace eCommerce.Application.Services;

public interface IProductService
{
    // public Task<ICollection<ProductDto>> SearchProducts(string searchTerm);
    public Task<IEnumerable<ProductDto>> GetProducts(string merchantName);
    public Task<IEnumerable<ProductDto>> GetProducts(string merchantName, string CategoryName);

}
