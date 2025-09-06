using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper; 
        public AdminController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("pending-products")]
        public async Task<IActionResult> GetPendingProducts()
        {
            var products = await _context.Products
                .Where(p => !p.IsApproved)
                .Include(p => p.CreatedBy)
                .ToListAsync();

            var productDtos = _mapper.Map<List<ProductDto>>(products); 

            return Ok(productDtos);
        }

        [HttpPost("approve/{id}")]
        public async Task<IActionResult> ApproveProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound("Product not found");

            product.IsApproved = true;
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Product approved successfully" });
        }

        [HttpPost("reject/{id}")]
        public async Task<IActionResult> RejectProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound("Product not found");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Product rejected and deleted" });
        }
    }
}
