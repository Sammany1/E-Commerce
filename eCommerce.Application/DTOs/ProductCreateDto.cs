using eCommerce.Domain.Models;

namespace eCommerce.Application.DTOs;

public class ProductCreateDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int MerchantId { get; set; }
    public ProductFlags Status { get; set; }

    public Product MapToProduct()
    {
        Product product = new Product
        {
            Name = Name,
            Price = Price,
            CategoryId = CategoryId,
            MerchantId = MerchantId,
            Status = Status
        };
        return product;
    }
}