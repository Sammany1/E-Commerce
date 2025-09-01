namespace eCommerce.Domain.Models;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public ICollection<Merchant> Merchants { get; set; }
}

public enum UserRole
{
    Customer,
    Admin
}