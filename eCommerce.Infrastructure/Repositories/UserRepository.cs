using eCommerce.Application.Repositories;
using eCommerce.Domain.Models;
using eCommerce.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public class UserRepository(eCommerceDbContext context) : BaseRepository<User>(context), IUserRepository
{
    private readonly DbSet<User> _users = context.Set<User>();

    public async Task<User> GetUserByUsername(string username)
    {
        return await _users.FirstOrDefaultAsync(user => user.Username.ToLower() == username.ToLower());
    }
    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _users.AnyAsync(u => u.Username.ToLower() == username.ToLower());
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _users.AnyAsync(u => u.Email == email.ToLower());
    }
    public async Task<(bool usernameExists, bool emailExists)> CheckUsernameAndEmailExistsAsync(string username, string email)
    {
        var usernameExists = await _users.AnyAsync(u => u.Username.ToLower() == username.ToLower());
        var emailExists = await _users.AnyAsync(u => u.Email == email.ToLower());

        return (usernameExists, emailExists);
    }
}
