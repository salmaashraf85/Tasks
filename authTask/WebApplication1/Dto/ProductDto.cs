namespace WebApplication1.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? FilePath { get; set; }
        public IFormFile Image { get; set; }
    }
}
