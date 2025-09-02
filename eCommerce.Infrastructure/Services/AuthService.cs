using static BCrypt.Net.BCrypt;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Domain.Models;

namespace eCommerce.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<LoginResult> Login(LoginUserRequest loginUser)
    {
        User user = await _userRepository.GetUserByUsername(loginUser.Username);
        if (user == null)
            return new LoginResult { Success = false, Message = "User not found" };

        if (!Verify(loginUser.Password, user.Password))
            return new LoginResult { Success = false, Message = "Wrong Password" };

        return new LoginResult { Success = true, user = user };
        // and token 

    }

    public async Task<RegisterResult> Register(RegisterUserRequest registerUser)
    {

        // manage Null fields 
        
        if (await _userRepository.UsernameExistsAsync(registerUser.Username))
            return new RegisterResult { Success = false, Message = "Username Already Exist" };

        if (await _userRepository.EmailExistsAsync(registerUser.Email))
            return new RegisterResult { Success = false, Message = "Email Already Exist" };
        User user = new User
        {
            Username = registerUser.Username,
            FirstName = registerUser.FirstName,
            LastName = registerUser.LastName,
            Password = HashPassword(registerUser.Password),
            Email = registerUser.Email.ToLower(),
            DateOfBirth = registerUser.DateOfBirth,
        };
        await _userRepository.Create(user);
        User createdUser = await _userRepository.GetById(user.Id);
        return new RegisterResult { Success = true, user = createdUser };
    }
}
