using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.DTOs;
using eCommerce.Domain.Models;

namespace eCommerce.Infrastructure.Services;

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
}
