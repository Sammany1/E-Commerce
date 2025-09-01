using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Models;

public class Merchant : BaseEntity
{
    public string MerchantName { get; set; }

    [ForeignKey("AdminId")]
    public User User { get; set; }
    public int AdminId { get; set; }
    public ICollection<Product> Products { get; set; }
}
