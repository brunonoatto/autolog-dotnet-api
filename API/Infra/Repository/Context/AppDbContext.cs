using AutologApi.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.Infra.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext> Options) : DbContext(Options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Garage> Garages => Set<Garage>();
        public DbSet<Budget> Budgets => Set<Budget>();
        public DbSet<BudgetItem> BudgetItems => Set<BudgetItem>();
        public DbSet<Car> Cars => Set<Car>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbName = Environment.GetEnvironmentVariable("DB_NAME");
            string dbUser = Environment.GetEnvironmentVariable("DB_USER");
            string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
            string connString =
                $"Server={dbName};Pooling=true;Database={dbName};User Id={dbUser};Password={dbPassword};";
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_URL"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
