using eCommerce.Infrastructure.Interfaces.Services;
using eCommerce.Infrastructure.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _user;
        public UsersController(IUserService user)
        {
            _user = user;
        }

        [HttpGet("{username}")]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetUserByUsername(string username)
        {
            UserDto user = await _user.GetUserByUsername(username);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
