﻿namespace WebApplication1.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int Quantity { get; set; }   
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

       
    }
}
