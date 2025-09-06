using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpPost("add/{productId}")]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized("User not found");

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId && p.IsApproved);
            if (product == null) return BadRequest("Product not available or not approved");

            var cartItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.ProductId == productId && c.UserId == userId);

            if (cartItem != null)
            {
                cartItem.Quantity += 1; 
            }
            else
            {
                cartItem = new Cart
                {
                    ProductId = productId,
                    UserId = userId,
                    Quantity = 1
                };
                _context.Carts.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return Ok(new { Message = "Product added to cart", Data = cartItem });
        }
    }
}
