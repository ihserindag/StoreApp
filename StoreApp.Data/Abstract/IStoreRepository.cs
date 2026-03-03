using StoreApp.Data.Concrete;

namespace StoreApp.Data.Abstract
{
    public interface IStoreRepository
    {
       IQueryable<Product> Products { get; }
       IQueryable<Category> Categories { get; }
       void CreateProduct(Product entity);
       void UpdateProduct(Product entity);
       void DeleteProduct(Product entity);
        int GetProductCount(string category);
        IEnumerable<Product> GetProducts(string category, int page, int pageSize);
       
    }
}