using System.Net.Mail;
using static BCrypt.Net.BCrypt;
using eCommerce.Infrastructure.Interfaces.Repositories;
using eCommerce.Infrastructure.Interfaces.Services;
using eCommerce.Infrastructure.DTOs;
using eCommerce.Domain.Models;

namespace eCommerce.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }
    public async Task<LoginResult> Login(LoginUserRequest loginUser)
    {
        if (string.IsNullOrEmpty(loginUser.Username))
            return new LoginResult { Success = false, Message = "Username is Required" };
        if (string.IsNullOrEmpty(loginUser.Password))
            return new LoginResult { Success = false, Message = "Password is Required" };

        User user = await _userRepository.GetUserByUsername(loginUser.Username);
        if (user == null)
            return new LoginResult { Success = false, Message = "User not found" };

        if (!Verify(loginUser.Password, user.Password))
            return new LoginResult { Success = false, Message = "Wrong Password" };
        string generatedToken = _tokenService.GenerateToken(user.Id, user.Username, user.Email, user.Role.ToString());
        return new LoginResult
        {
            Success = true,
            Data = new AuthResponse
            {
                Token = generatedToken,
                User = new UserDto(user)
            }
        };
    }

    public async Task<RegisterResult> Register(RegisterUserRequest registerUser, UserRole role = UserRole.Customer)
    {

        RegisterResult validationResult = ValidateRegistrationRequest(registerUser);
        if (validationResult != null)
            return validationResult;

        var (usernameExists, emailExists) = await _userRepository.CheckUsernameAndEmailExistsAsync(registerUser.Username, registerUser.Email);

        if (usernameExists)
            return new RegisterResult { Success = false, Message = "Username Already Exist" };

        if (emailExists)
            return new RegisterResult { Success = false, Message = "Email Already Exist" };

        User user = new User
        {
            Username = registerUser.Username,
            FirstName = registerUser.FirstName,
            LastName = registerUser.LastName,
            Password = HashPassword(registerUser.Password),
            Role = role,
            Email = registerUser.Email.ToLower(),
            DateOfBirth = registerUser.DateOfBirth,
        };
        await _userRepository.Create(user);
        string generatedToken = _tokenService.GenerateToken(user.Id, user.Username, user.Email, user.Role.ToString());
        return new RegisterResult
        {
            Success = true,
            Data = new AuthResponse
            {
                Token = generatedToken,
                User = new UserDto(user)
            }
        };
    }

    public async Task<RegisterResult> RegisterAdmin(RegisterUserRequest registerUser)
    {
        RegisterResult registerResult = await Register(registerUser, UserRole.Admin);
        return registerResult;
    }

    private RegisterResult ValidateRegistrationRequest(RegisterUserRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username))
            return new RegisterResult { Success = false, Message = "Username is required" };

        if (string.IsNullOrWhiteSpace(request.FirstName))
            return new RegisterResult { Success = false, Message = "First name is required" };

        if (string.IsNullOrWhiteSpace(request.LastName))
            return new RegisterResult { Success = false, Message = "Last name is required" };

        if (string.IsNullOrWhiteSpace(request.Password))
            return new RegisterResult { Success = false, Message = "Password is required" };

        if (request.Password.Length < 6)
            return new RegisterResult { Success = false, Message = "Password must be at least 6 characters" };

        if (string.IsNullOrWhiteSpace(request.Email))
            return new RegisterResult { Success = false, Message = "Email is required" };

        if (!IsValidEmail(request.Email))
            return new RegisterResult { Success = false, Message = "Invalid email format" };

        return null;
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
