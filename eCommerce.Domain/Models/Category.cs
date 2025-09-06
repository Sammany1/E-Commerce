namespace eCommerce.Domain.Models;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }

    public Category(string name)
    {
        Name = name;
    }
}
