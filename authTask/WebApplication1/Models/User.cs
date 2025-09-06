using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public string Name { get; set; }


        //product
        public ICollection<Product> Products { get; set; }

        //cart
        public ICollection<Cart> CartItems { get; set; }
    }
}
