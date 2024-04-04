using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataShopTest.Models;

namespace ValidataShopTest.DAL.Repositories
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private ValidataShopContext _context;
        public OrderRepository(ValidataShopContext context)
        {
            _context = context;
        }

        public async Task<Order> AddAsync(Order entity)
        {
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order entity)
        {
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return _context.Orders.ToList();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        //implement GetOrdersOfCustomerAsync
        public async Task<IEnumerable<Order>> GetOrdersOfCustomerAsync(int customerId)
        {
            return _context.Orders.Where(o => o.CustomerId == customerId).ToList();
        }

        //implement GetOrderItemsByOrderIdAsync
        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return _context.OrderItems.Where(oi => oi.OrderId == orderId).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}