using Microsoft.EntityFrameworkCore;
using RestAPI.Database.Models;

namespace RestAPI.Database
{
    public class MyDbContext : DbContext
    {        
        public MyDbContext(DbContextOptions<MyDbContext> options) 
            : base(options)
        {
        }
        public DbSet<WeatherForecast> WeatherForecast { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>(entity =>
            {
                entity.HasKey(e => new { e.Id });
                entity.HasData(
                    new WeatherForecast { Id = 1, Date = new DateOnly(2023, 1, 1), TemperatureC = -5, Summary = "Freezing" },
                    new WeatherForecast { Id = 2, Date = new DateOnly(2023, 1, 2), TemperatureC = 0, Summary = "Bracing" },
                    new WeatherForecast { Id = 3, Date = new DateOnly(2023, 1, 3), TemperatureC = 5, Summary = "Chilly" },
                    new WeatherForecast { Id = 4, Date = new DateOnly(2023, 1, 4), TemperatureC = 10, Summary = "Cool" },
                    new WeatherForecast { Id = 5, Date = new DateOnly(2023, 1, 5), TemperatureC = 15, Summary = "Mild" },
                    new WeatherForecast { Id = 6, Date = new DateOnly(2023, 1, 6), TemperatureC = 20, Summary = "Warm" },
                    new WeatherForecast { Id = 7, Date = new DateOnly(2023, 1, 7), TemperatureC = 25, Summary = "Balmy" },
                    new WeatherForecast { Id = 8, Date = new DateOnly(2023, 1, 8), TemperatureC = 30, Summary = "Hot" },
                    new WeatherForecast { Id = 9, Date = new DateOnly(2023, 1, 9), TemperatureC = 35, Summary = "Sweltering" },
                    new WeatherForecast { Id = 10, Date = new DateOnly(2023, 1, 10), TemperatureC = 40, Summary = "Scorching" }
                );
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MyDatabase;Integrated Security=false; TrustServerCertificate=True;Encrypt=true;User ID=sa;Password=Password_123#;");
        }
    }
}
