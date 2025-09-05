using eCommerce.Domain.Models;

namespace eCommerce.Application.DTOs;

public class MerchantDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }

    public MerchantDto(Merchant merchant)
    {
        Id = merchant.Id;
        Name = merchant.Name;
        Products = merchant.Products;
    }
}
