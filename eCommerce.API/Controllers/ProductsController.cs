using System.Security.Claims;
using eCommerce.Application.DTOs;
using eCommerce.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMerchantService _merchantService;

        public ProductsController(IProductService productService, IMerchantService merchantService)
        {
            _productService = productService;
            _merchantService = merchantService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts(string category = null)
        {
            if (!string.IsNullOrWhiteSpace(category))
            {
                var productsByCategory = await _productService.GetAllProductsByCategory(category);
                return Ok(productsByCategory);
            }

            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> SearchProducts([FromQuery] string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return BadRequest("Search term cannot be empty");

            var products = await _productService.SearchProducts(searchTerm);
            return Ok(products);
        }

        [HttpGet("merchant/{merchantId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByMerchant(int merchantId, [FromQuery] string category = null)
        {
            if (merchantId <= 0)
                return BadRequest("Invalid merchant ID");

            if (!string.IsNullOrWhiteSpace(category))
            {
                var productsByMerchantAndCategory = await _productService.GetProductsByMerchantAndCategory(merchantId, category);
                return Ok(productsByMerchantAndCategory);
            }

            var products = await _productService.GetProductsByMerchant(merchantId);
            return Ok(products);
        }

        [HttpGet("merchant/{merchantId}/search")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> SearchProductsByMerchant(int merchantId, [FromQuery] string searchTerm)
        {
            if (merchantId <= 0)
                return BadRequest("Invalid merchant ID");

            if (string.IsNullOrWhiteSpace(searchTerm))
                return BadRequest("Search term cannot be empty");

            var products = await _productService.SearchProductsByMerchant(merchantId, searchTerm);
            return Ok(products);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductCreateDto productDto)
        {
            if (productDto == null)
                return BadRequest("Product data is required");

            string adminIdString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            MerchantDto merchant = await _merchantService.GetMerchantById(productDto.MerchantId);
            if (int.Parse(adminIdString) != merchant.AdminId)
                return Forbid("You are not authorized to create a product for this merchant.");

            var createdProduct = await _productService.CreateProduct(productDto);
            if (createdProduct == null)
                return BadRequest("Failed to create product");

            return StatusCode(201, createdProduct);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, ProductUpdateDto productDto)
        {
            if (productDto == null)
                return BadRequest("Product data is required");

            string adminIdString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var product = await _productService.GetProductById(productDto.Id);
            if (product == null)
                return BadRequest();

            var merchant = await _merchantService.GetMerchantById(product.MerchantId);
            if (merchant == null)
                return BadRequest();

            if (int.Parse(adminIdString) != merchant.AdminId)
                return Forbid("You are not authorized to update this product for this merchant.");

            if (id != productDto.Id)
                return BadRequest("ID mismatch");

            var updatedProduct = await _productService.UpdateProduct(productDto);
            if (updatedProduct == null)
                return NotFound($"Product with ID {id} not found");

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid product ID");

            string adminIdString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var product = await _productService.GetProductById(id);
            if (product == null)
                return BadRequest();

            var merchant = await _merchantService.GetMerchantById(product.MerchantId);
            if (merchant == null)
                return BadRequest();

            if (int.Parse(adminIdString) != merchant.AdminId)
                return Forbid("You are not authorized to delete this product for this merchant.");

            var result = await _productService.DeleteProduct(id);
            if (!result)
                return NotFound($"Product with ID {id} not found");

            return NoContent();
        }
    }
}