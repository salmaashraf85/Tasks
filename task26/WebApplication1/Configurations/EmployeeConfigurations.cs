using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(e => e.department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DeptNo)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
