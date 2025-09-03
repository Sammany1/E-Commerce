namespace eCommerce.Domain.Models;

public class AuthResponse
{
    public string Token { get; set; }
    public string TokenTyep { get; set; } = "Bearer";
    public int ExpiresIn { get; set; } = 3600;
    public UserDto User { get; set; }
}
