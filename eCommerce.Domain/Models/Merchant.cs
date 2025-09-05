using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Models;

public class Merchant : BaseEntity
{
    public string Name { get; set; }

    [ForeignKey("AdminId")]
    public User User { get; set; }
    public int AdminId { get; set; }
    public ICollection<Product> Products { get; set; }

    public Merchant(string name, int adminId)
    {
        Name = name;
        AdminId = adminId;
    }
}
