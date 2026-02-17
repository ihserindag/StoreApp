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
    }
}