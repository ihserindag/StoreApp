using StoreApp.Data.Concrete;

namespace StoreApp.Data.Abstract
{
    public interface IStoreRepository
    {
       IQueryable<Product> Products { get; }  
       void CreateProduct(Product entity);
       void UpdateProduct(Product entity);
       void DeleteProduct(Product entity);
    }
}