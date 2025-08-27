namespace WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
          public DbSet<Employee> Employees { get; set; }
          public DbSet<Role> Roles { get; set; }
          public DbSet<Department> Departments { get; set; }
          public DbSet<Login> Logins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //emp and role relation

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.role)
            .WithMany(r => r.employees)
            .HasForeignKey(e => e.RoleId);


        //departement and emp relation
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DeptId);

        

        //emp and login relation

        modelBuilder.Entity<Login>()
            .HasOne(l => l.Emp)
            .WithMany(e => e.Logins)
            .HasForeignKey(l =>l.EmpId);

       


    }
}

