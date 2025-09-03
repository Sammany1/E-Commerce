namespace eCommerce.Domain.Models;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public UserDto(User user)
    {
        Id = user.Id;
        Username = user.Username;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
        Role = user.Role.ToString();
        DateOfBirth = user.DateOfBirth;
    }
}

