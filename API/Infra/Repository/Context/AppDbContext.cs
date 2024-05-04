using Domain.Model;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<User> Users => Set<User>();
  public DbSet<Garage> Garages => Set<Garage>();

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    // optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
    base.OnConfiguring(optionsBuilder);
  }
}