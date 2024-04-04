using ValidataShopTest.Models;

namespace ValidataShopTest.DAL.Repositories
{
    public interface IProductRepository : IDisposable
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> AddAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task DeleteAsync(Product entity);
    }
}
