using eCommerce.Application.DTOs;
using eCommerce.Domain.Models;

namespace eCommerce.Application.Services;

public interface IAuthService
{
    public Task<LoginResult> Login(LoginUserRequest loginUser);
    public Task<RegisterResult> Register(RegisterUserRequest registerUser,  UserRole role = UserRole.Customer);
    public Task<RegisterResult> RegisterAdmin(RegisterUserRequest registerUser);

}