using DanieliPetShop.Models;
using Microsoft.EntityFrameworkCore;

namespace DanieliPetShop.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Review>? Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //creating all the init database.
        {
            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, Name = "Mammal" },
                new { CategoryId = 2, Name = "Bird" },
                new { CategoryId = 3, Name = "Reptile" },
                new { CategoryId = 4, Name = "Fish" }
            );
            
            modelBuilder.Entity<Animal>().HasData(
                new { AnimalId = 1, Name = "beast", Age = 5, Picture = "bearPhoto.jpg" , CategoryId = 1, Price = 10000,
                    Description = "A huge bear, very friendly and loves human" },
                new { AnimalId = 2, Name = "arrow", Age = 3, Picture = "eaglePhoto.jpg", CategoryId = 2, Price = 15000,
                    Description = "A large and powerful eagle" },
                new { AnimalId = 3, Name = "yeshu", Age = 45, Picture = "turtlePhoto.jpg", CategoryId = 3, Price = 11000,
                    Description = "A terrific and huge turtle" }
            );

            modelBuilder.Entity<Review>().HasData(
                new { ReviewId = 1, AnimalId = 1, Text = "Great price", Writer= "moshe"},
                new { ReviewId = 2, AnimalId = 2, Text = "Quick delivery", Writer = "anat" },
                new { ReviewId = 3, AnimalId = 1, Text = "8 feet tall", Writer = "david" },
                new { ReviewId = 4, AnimalId = 2, Text = "huge wings width", Writer = "josh" },
                new { ReviewId = 5, AnimalId = 3, Text = "crawling slowly", Writer = "drake" }
            );
        }
    }
}
