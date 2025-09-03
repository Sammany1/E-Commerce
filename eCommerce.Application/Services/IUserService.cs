using eCommerce.Domain.Models;

namespace eCommerce.Application.Services;

public interface IUserService
{
    public Task<UserDto> GetUserByUsername(string username);
}
