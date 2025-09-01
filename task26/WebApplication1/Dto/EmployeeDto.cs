using WebApplication1.Models;

namespace WebApplication1.Dto
{
    public class EmployeeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Gender{ get; set; } = string.Empty;

        public DateTime Dob { get; set; }
        public DateTime Doj { get; set; }
        public int DeptNo { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        //public List<DependentDto>? Dependents { get; set; }
    }
}
