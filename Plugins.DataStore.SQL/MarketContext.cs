using Microsoft.EntityFrameworkCore;
using CoreBusiness;
namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage" },

                new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery" },

                new Category { CategoryId = 3, Name = "Meat", Description = "Meat" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product(1, 1, "Iced Tea", 1.99, 100),
                new Product(2, 1, "Canada Dry", 1.99, 200),
                new Product(3, 2, "Whole Wheat Bread", 1.99, 100),
                new Product(4, 2, "White Bread", 1.99, 100)
                );
        }
    }
}