using eCommerce.Infrastructure.Interfaces.Services;
using eCommerce.Infrastructure.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _user;
        public UsersController(IUserService user)
        {
            _user = user;
        }

        [HttpGet("me")]
        public async Task<ActionResult<UserProfileDto>> GetProfile()
        {
            string userIdString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _user.GetProfile(int.Parse(userIdString));
            return Ok(user);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserDto>> GetUserByUsername(string username)
        {
            UserDto user = await _user.GetUserByUsername(username);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
