using eCommerce.Domain.Models;

namespace eCommerce.Infrastructure.Interfaces.Repositories;
public interface IUserRepository : IBaseRepository<User>
{
    public Task<User> GetUserByUsername(string username);
    public Task<bool> UsernameExistsAsync(string username);
    public Task<bool> EmailExistsAsync(string email);
    public Task<(bool usernameExists, bool emailExists)> CheckUsernameAndEmailExistsAsync(string username, string email);
}
