namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? FilePath { get; set; } 
        public bool IsApproved { get; set; } 

     
        public string CreatedById { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }

        public virtual ICollection<Cart> CartItems { get; set; }
    }

}
