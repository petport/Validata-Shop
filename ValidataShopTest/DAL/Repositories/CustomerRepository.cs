using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataShopTest.Models;

namespace ValidataShopTest.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private ValidataShopContext _context;
        public CustomerRepository(ValidataShopContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Customer entity)
        {
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return _context.Customers.ToList();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task UpdateAsync(Customer entity)
        {
            _context.Customers.Update(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
