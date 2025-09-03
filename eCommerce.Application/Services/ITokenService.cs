namespace eCommerce.Application.Services;

public interface ITokenService
{
    string GenerateToken(string username, string email, string role);
    bool ValidateToken(string token);
    Dictionary<string, string> GetClaimsFromToken(string token);
}