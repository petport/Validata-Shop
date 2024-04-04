using ValidataShopTest.Models;

namespace ValidataShopTest.DAL.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private ValidataShopContext _context;
        public ProductRepository(ValidataShopContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Product entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return _context.Products.ToList();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
