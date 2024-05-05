using AutologApi.API.Domain.Model;
using AutologApi.API.Settings;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.Infra.Repository;
public class AppDbContext(DbContextOptions<AppDbContext> Options) : DbContext(Options)
{
  public DbSet<User> Users => Set<User>();
  public DbSet<Garage> Garages => Set<Garage>();

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Pooling=true;Database=AUTOLOG_DB;User Id=postgres;Password=1234;");
    // optionsBuilder.UseNpgsql(AppSettings.ConnectionStrings.DefaultConnection);
    base.OnConfiguring(optionsBuilder);
  }
}