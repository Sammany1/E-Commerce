namespace eCommerce.Domain.Models;

public class Category : BaseEntity
{
    public string CategoryName { get; set; }

    public ICollection<Product> Products { get; set; }
}
