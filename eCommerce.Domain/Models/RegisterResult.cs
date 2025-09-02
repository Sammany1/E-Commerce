namespace eCommerce.Domain.Models;

public class RegisterResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public User? user { get; set; }
}
