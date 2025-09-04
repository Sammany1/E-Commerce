using eCommerce.Application.Services;
using eCommerce.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginUserRequest loginUser)
        {
            LoginResult loginResult = await _authService.Login(loginUser);
            if (loginResult.Success == false)
                return Unauthorized(loginResult.Message);

            return Ok(loginResult);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterUserRequest registerUser)
        {
            RegisterResult registerResult = await _authService.Register(registerUser);
            if (registerResult.Success == false)
                return BadRequest(registerResult.Message);

            return StatusCode(201, registerResult.Data);
        }

        [HttpPost]
        [Route("register-admin")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult> RegisterAdmin(RegisterUserRequest registerUser)
        {
            RegisterResult registerResult = await _authService.RegisterAdmin(registerUser);
            if (registerResult.Success == false)
                return BadRequest(registerResult.Message);

            return StatusCode(201, registerResult.Data);
        }

    }
}
