using eCommerce.Domain.Models;

namespace eCommerce.Infrastructure.DTOs;

public class MerchantDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AdminId { get; set; }
    public ICollection<Product> Products { get; set; }

    public MerchantDto(Merchant merchant)
    {
        Id = merchant.Id;
        Name = merchant.Name;
        AdminId = merchant.AdminId;
        Products = merchant.Products;
    }
}
