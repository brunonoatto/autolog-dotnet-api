using AutologApi.API.Domain.Model;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<User> Users => Set<User>();
  public DbSet<Garage> Garages => Set<Garage>();

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Pooling=true;Database=AUTOLOG_DB;User Id=postgres;Password=1234;");
    base.OnConfiguring(optionsBuilder);
  }
}