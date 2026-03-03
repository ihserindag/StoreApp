using StoreApp.Data.Abstract;

namespace StoreApp.Data.Concrete
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext _context;
        public EFStoreRepository(StoreDbContext context)
        {
            _context=context;
        }

        public IQueryable<Product> Products => _context.Products;
        public IQueryable<Category> Categories => _context.Categories;


        public void CreateProduct(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
        }

        public int GetProductCount(string category)
        {
             var productsQuery = _context.Products.AsQueryable();
              if (!string.IsNullOrEmpty(category))
            {
                productsQuery = productsQuery.Where(p => p.Categories.Any(c => c.Url == category));
            }

           return  productsQuery.Count();
        }

        public IEnumerable<Product> GetProducts(string category, int page, int pageSize)
        {
            var productsQuery = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                productsQuery = productsQuery.Where(p => p.Categories.Any(c => c.Url == category));
            }

            return productsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}