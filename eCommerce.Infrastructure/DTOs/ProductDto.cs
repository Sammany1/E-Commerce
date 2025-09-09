using eCommerce.Domain.Models;

namespace eCommerce.Infrastructure.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductFlags Status { get; set; } = ProductFlags.Active & ProductFlags.InStock;
    public int MerchantId { get; set; }
    public int CategoryId { get; set; }


    public ProductDto(Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Price = product.Price;
        Status = product.Status;
        MerchantId = product.MerchantId;
        CategoryId = product.CategoryId;
    }
}
