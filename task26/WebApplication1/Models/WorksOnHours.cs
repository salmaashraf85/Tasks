namespace WebApplication1.Models
{
    public class WorksOnHours
    {
        public int EmpId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public int Hours {  get; set; }
    }
}
