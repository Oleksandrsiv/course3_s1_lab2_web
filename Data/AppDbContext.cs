using course3_s1_lab1_web.Models;
using Microsoft.EntityFrameworkCore;

namespace course3_s1_lab1_web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Factory> Factories { get; set; }
    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Factory>().HasData(
            new Factory { Id = 1, Name = "Subaru" },
            new Factory { Id = 2, Name = "Hyundai" },
            new Factory { Id = 3, Name = "Volkswagen" }
        );

        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, ModelName = "Impreza", FactoryId = 1 },
            new Car { Id = 2, ModelName = "Tucson", FactoryId = 2 },
            new Car { Id = 3, ModelName = "Golf", FactoryId = 3 }
        );
    }
}