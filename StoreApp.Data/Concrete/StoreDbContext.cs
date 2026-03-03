using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concrete
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }
        
        public DbSet<Product> Products=>Set<Product>();
        public DbSet<Category> Categories=>Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Categories)
                .WithMany(e => e.Products)
                .UsingEntity<ProductCategory>();

            modelBuilder.Entity<Category>()
                .HasIndex(e => e.Url)
                .IsUnique();



            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Samsung S25", Price = 1000, Description = "Güzel Telefon" },
                new Product() { Id = 2, Name = "Samsung S24", Price = 2000, Description = "Güzel Telefon" },
                new Product() { Id = 3, Name = "Samsung S23", Price = 3000, Description = "Güzel Telefon" },
                new Product() { Id = 4, Name = "Samsung S22", Price = 4000, Description = "Güzel Telefon" },
                new Product() { Id = 5, Name = "Samsung S21", Price = 5000, Description = "Güzel Telefon" },
                new Product() { Id = 6, Name = "Samsung S20", Price = 6000, Description = "Güzel Telefon" },
                new Product() { Id = 7, Name = "Samsung S10", Price = 7000, Description = "Güzel Telefon" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Telefon", Url = "telefon" },
                new Category() { Id = 2, Name = "Bilgisayar", Url = "bilgisayar" },
                new Category() { Id = 3, Name = "Elektronik", Url = "elektronik" },
                new Category() { Id = 4, Name = "Beyaz Eşya", Url = "beyaz-esya" },
                new Category() { Id = 5, Name = "Küçük Ev Aletleri", Url = "kucuk-ev-aletleri" }
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory() { ProductId = 1, CategoryId = 1 },
                new ProductCategory() { ProductId = 2, CategoryId = 1 },
                new ProductCategory() { ProductId = 3, CategoryId = 2 },
                new ProductCategory() { ProductId = 4, CategoryId = 2 },
                new ProductCategory() { ProductId = 5, CategoryId = 3 },
                new ProductCategory() { ProductId = 6, CategoryId = 3 },
                new ProductCategory() { ProductId = 7, CategoryId = 2 }
            );

        }
    }
}
