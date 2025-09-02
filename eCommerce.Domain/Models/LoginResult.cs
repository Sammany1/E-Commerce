namespace eCommerce.Domain.Models;

public class LoginResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public User? user { get; set; }
    // token
}
