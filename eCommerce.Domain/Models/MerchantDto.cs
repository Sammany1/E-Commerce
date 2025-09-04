namespace eCommerce.Domain.Models;

public class MerchantDto
{
    public int Id { get; set; }
    public string MerchantName { get; set; }
    public ICollection<Product> Products { get; set; }

    public MerchantDto(Merchant merchant)
    {
        Id = merchant.Id;
        MerchantName = merchant.MerchantName;
        Products = merchant.Products;
    }
}
