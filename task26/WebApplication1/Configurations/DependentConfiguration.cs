using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class DependentConfiguration :IEntityTypeConfiguration<Dependent>
    {
        public void Configure(EntityTypeBuilder<Dependent> builder)
        {
            builder.HasKey(d => new {d.EmpId,d.Dname});

            builder.HasOne(d => d.Employee)
              .WithMany(e => e.Dependents)
              .HasForeignKey(d => d.EmpId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
