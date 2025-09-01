namespace eCommerce.Domain.Models;


public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductFlags status { get; set; }

    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public Merchant Merchant { get; set; }
    public int MerchantId { get; set; }
}

[Flags]
public enum ProductFlags
{
    None = 0,
    Active = 1,
    InStock = 2,
}