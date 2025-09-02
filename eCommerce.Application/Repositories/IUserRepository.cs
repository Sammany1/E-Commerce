using eCommerce.Domain.Models;

namespace eCommerce.Application.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    public Task<User> GetUserByUsername(string username);
    public Task<bool> UsernameExistsAsync(string username);
    public Task<bool> EmailExistsAsync(string email);
}
