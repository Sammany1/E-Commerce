using eCommerce.Infrastructure.Interfaces.Repositories;
using eCommerce.Infrastructure.Interfaces.Services;
using eCommerce.Infrastructure.DTOs;
using eCommerce.Domain.Models;

namespace eCommerce.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _user;

    public UserService(IUserRepository user)
    {
        _user = user;
    }
    public async Task<UserDto> GetUserByUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
            return null;
        User user = await _user.GetUserByUsername(username);
        if (user == null)
            return null;
        UserDto userDto = new UserDto(user);
        return userDto;
    }

    public async Task<UserProfileDto> GetProfile(int id)
    {
        var user = await _user.GetById(id);
        return new UserProfileDto(user);
    }
}
