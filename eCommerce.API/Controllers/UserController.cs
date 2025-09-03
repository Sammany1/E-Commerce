using eCommerce.Application.Services;
using eCommerce.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;
        public UserController(IUserService user)
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
