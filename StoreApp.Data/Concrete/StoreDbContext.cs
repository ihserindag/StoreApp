using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concrete
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }
        
        public DbSet<Product> Products=>Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Samsung S25", Price = 1000, Description = "Güzel Telefon", Category = "Telefon" },
                new Product() { Id = 2, Name = "Samsung S24", Price = 2000, Description = "Güzel Telefon", Category = "Telefon" },
                new Product() { Id = 3, Name = "Samsung S23", Price = 3000, Description = "Güzel Telefon", Category = "Telefon" },
                new Product() { Id = 4, Name = "Samsung S22", Price = 4000, Description = "Güzel Telefon", Category = "Telefon" },
                new Product() { Id = 5, Name = "Samsung S21", Price = 5000, Description = "Güzel Telefon", Category = "Telefon" },
                new Product() { Id = 6, Name = "Samsung S20", Price = 6000, Description = "Güzel Telefon", Category = "Telefon" },
                new Product() { Id = 7, Name = "Samsung S10", Price = 7000, Description = "Güzel Telefon", Category = "Telefon" }
            );
        }
    }
}
