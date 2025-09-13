using eCommerce.Infrastructure.DTOs;

namespace eCommerce.Infrastructure.Interfaces.Services;

public interface IUserService
{
    public Task<UserDto> GetUserByUsername(string username);
    public Task<UserProfileDto> GetProfile(int id);
}
