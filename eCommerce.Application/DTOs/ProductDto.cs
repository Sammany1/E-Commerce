using eCommerce.Domain.Models;

namespace eCommerce.Application.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductFlags status { get; set; }

    public ProductDto(Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Price = product.Price;
        status = product.status;
    }
}
