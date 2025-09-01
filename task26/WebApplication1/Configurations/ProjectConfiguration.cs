using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasOne(p => p.Depratment)
                .WithMany(d => d.Projects)
                .HasForeignKey(p => p.Dno).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
