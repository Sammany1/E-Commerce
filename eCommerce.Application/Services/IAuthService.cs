using eCommerce.Domain.Models;

namespace eCommerce.Application.Services;

public interface IAuthService
{
    public Task<LoginResult> Login(LoginUserRequest loginUser);
    public Task<RegisterResult> Register(RegisterUserRequest registerUser);
}