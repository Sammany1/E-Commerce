using System.Security.Claims;
using eCommerce.Application.Services;
using eCommerce.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantService _merchant;

        public MerchantController(IMerchantService merchant)
        {
            _merchant = merchant;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(MerchantRequest merchant)
        {
            string adminIdString = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            MerchantDto merchantDto = await _merchant.Create(merchant.MerchantName, int.Parse(adminIdString));
            if (merchantDto == null)
                return BadRequest("merchant name already exist!");

            return StatusCode(201, merchantDto);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<MerchantDto>>> SearchMerchants([FromQuery] string name)
        {
            var merchants = await _merchant.SearchMerchantsByName(name);
            return Ok(merchants);
        }
    }
}
