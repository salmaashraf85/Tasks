using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>

    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.HasMany(c => c.Students)
                .WithMany(s => s.Courses);
        }
    }
}
