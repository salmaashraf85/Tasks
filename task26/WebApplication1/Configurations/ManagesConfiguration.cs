using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class ManageConfiguration : IEntityTypeConfiguration<Manages>
    {
        public void Configure(EntityTypeBuilder<Manages> builder)
        {
            
            builder.HasOne(m => m.Employee)
                .WithMany(e => e.ManagedDepartments)
                .HasForeignKey(m => m.EmployeeId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Department)
               .WithOne(d => d.Manager)
               .HasForeignKey<Manages>(m => m.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
