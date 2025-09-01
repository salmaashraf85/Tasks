using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }



    public DbSet<Employee> Employees { get; set; }
    public DbSet<Depratment> Depratments { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<WorksOnHours> WorksOnHours { get; set; }
    public DbSet<Dependent> Dependents { get; set; }
    public DbSet<Manages> Manages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        base.OnModelCreating(modelBuilder);
      
    }


}
