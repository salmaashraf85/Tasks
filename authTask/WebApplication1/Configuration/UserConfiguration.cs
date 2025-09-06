using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configuration
{
    public class UserConfiguration:IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            
            builder.HasMany(u => u.Products)
                .WithOne(p => p.CreatedBy)
                .HasForeignKey(p => p.CreatedById).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
