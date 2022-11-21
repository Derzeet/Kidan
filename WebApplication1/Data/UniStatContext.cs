using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.Data;

public class UniStatContext : DbContext
{
    public UniStatContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Database=saske;Port=5432;User Id=postgres;Password=1844600");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }

    public DbSet<University> Universities { get; set; }
    public DbSet<Student> Students { get; set; }
}