namespace eCommerce.Application.DTOs;

public class RegisterResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public AuthResponse Data { get; set; }
}
