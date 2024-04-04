using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataShopTest.Models;

namespace ValidataShopTest.DAL.Repositories
{
    public interface IOrderRepository : IDisposable
    {
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> AddAsync(Order entity);
        Task UpdateAsync(Order entity);
        Task DeleteAsync(Order entity);
        Task<IEnumerable<Order>> GetOrdersOfCustomerAsync(int customerId);
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
    }
}
