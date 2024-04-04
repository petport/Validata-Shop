using Microsoft.AspNetCore.Mvc;
using ValidataShopTest.DAL.Repositories;
using ValidataShopTest.Models;

namespace ValidataShopTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }


        [HttpGet("OrdersOfCustomer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersOfCustomerByDate(int customerId)
        {

            var orders = await _unitOfWork.Orders.GetOrdersOfCustomerAsync(customerId);
            var orderIds1 = orders.Select(o => o.Id).OrderByDescending(o => o);
            var response = new List<Order>();
            foreach (var orderId in orderIds1)
            {
                var orderItems = await _unitOfWork.Orders.GetOrderItemsByOrderIdAsync(orderId);
                var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
                order.OrderItems = orderItems.ToList();
                response.Add(order);
            }

            return Ok(response);

        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            // Destructure the order object and print the values
            // Get the current date and time
            order.OrderDate = DateTime.Now;

            // Calculate the total price of the order
            /*
            {
                "CustomerId": 18,
                "OrderItems": [
                    {
                        "ProductId": 2,
                        "Quantity": 4
                    }
                ]
            }
            */
            var totalPrice = 0.0m;
            foreach (var orderItem in order.OrderItems)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(orderItem.ProductId);
                totalPrice += product.Price * orderItem.Quantity;
            }
            order.TotalPrice = totalPrice;

            var createdOrder = await _unitOfWork.Orders.AddAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            await _unitOfWork.Orders.UpdateAsync(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _unitOfWork.Orders.DeleteAsync(order);
            return NoContent();
        }
    }
}
