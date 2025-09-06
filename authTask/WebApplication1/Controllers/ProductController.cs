using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "ProductCreator,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct(ProductDto dto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized("User not found");

            var product = new Product
            {
                Name = dto.Name,
                FilePath = dto.FilePath,
                IsApproved = false,         
                CreatedById = userId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Product submitted for approval" });
        }



        [AllowAnonymous] 
        [HttpGet("get-approved")]
        public async Task<IActionResult> GetApprovedProducts()
        {
            var products = await _context.Products
                .Where(p => p.IsApproved)
                .Include(p => p.CreatedBy)
                .ToListAsync();

            return Ok(products);
        }

      
    }
}
