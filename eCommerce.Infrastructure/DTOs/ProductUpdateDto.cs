using eCommerce.Domain.Models;

namespace eCommerce.Infrastructure.DTOs;

public class ProductUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public ProductFlags Status { get; set; }

    public Product MapToProduct(Product product)
    {
        product.Name = Name;
        product.Price = Price;
        product.CategoryId = CategoryId;
        product.Status = Status;
        return product;
    }
}