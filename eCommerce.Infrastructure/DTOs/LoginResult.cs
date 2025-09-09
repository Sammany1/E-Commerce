namespace eCommerce.Infrastructure.DTOs;

public class LoginResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public AuthResponse? Data { get; set; }
    
}
