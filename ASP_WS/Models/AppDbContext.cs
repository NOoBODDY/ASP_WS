using Microsoft.EntityFrameworkCore;
namespace ASP_WS.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Breed> Breeds { get; set; } = null!;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breed>().HasData(
                new Breed { Id = 1, Name = "Дворняга", Description = "Обычная дворняга"},
                new Breed { Id = 2, Name = "Пудель", Description = "Пушистик"},
                new Breed { Id = 3, Name = "Такса", Description = "Сосиска"}
                );

        }
    }
}
