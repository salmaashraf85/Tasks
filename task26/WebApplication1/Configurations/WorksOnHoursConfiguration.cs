using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class WorksOnHoursConfiguration : IEntityTypeConfiguration<WorksOnHours>
    {
        public void Configure(EntityTypeBuilder<WorksOnHours> builder)
        {
           
            builder.HasKey(w => new { w.EmpId, w.ProjectId });

            builder.HasOne(w => w.Employee)
                   .WithMany(e => e.WorksOnHours)
                   .HasForeignKey(w => w.EmpId).OnDelete(DeleteBehavior.Restrict);



            builder.HasOne(w => w.Project)
                   .WithMany(p => p.WorksOnHours)
                   .HasForeignKey(w => w.ProjectId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
