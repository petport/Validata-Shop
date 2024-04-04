using ValidataShopTest.Models;

namespace ValidataShopTest.DAL.Repositories
{
    public interface ICustomerRepository : IDisposable
    {
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> AddAsync(Customer entity);
        Task UpdateAsync(Customer entity);
        Task DeleteAsync(Customer entity);
    }
}
