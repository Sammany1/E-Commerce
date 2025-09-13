using eCommerce.Domain.Models;

namespace eCommerce.Infrastructure.DTOs;

public class UserDto
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UserDto(User user)
    {
        Username = user.Username;
        FirstName = user.FirstName;
        LastName = user.LastName;
    }
}

