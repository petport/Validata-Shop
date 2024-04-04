using Microsoft.AspNetCore.Mvc;
using ValidataShopTest.Application.Commands;
using ValidataShopTest.Application.Queries;
using ValidataShopTest.DAL.Repositories;
using ValidataShopTest.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ValidataShopTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        /*
        private ICustomerRepository _customerRepository;

        
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        */
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandHandler<CreateCustomerCommand> _createCustomerCommandHandler;
        private readonly IQueryHandler<GetCustomerQuery, Customer> _getCustomerQueryHandler;

        public CustomersController(
            IUnitOfWork unitOfWork, 
            ICommandHandler<CreateCustomerCommand> commandHandler,
            IQueryHandler<GetCustomerQuery, Customer> getCustomerQueryHandler)
        {
            _unitOfWork = unitOfWork;
            _createCustomerCommandHandler = commandHandler;
            _getCustomerQueryHandler = getCustomerQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var query = new GetCustomerQuery(id);
            var customer = await _getCustomerQueryHandler.HandleAsync(query);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(CreateCustomerCommand command)
        {
            _createCustomerCommandHandler.HandleAsync(command);
            return CreatedAtAction(nameof(GetCustomer), new { id = command.Id }, command);
        }
        

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            Console.WriteLine("Updating customer with id: " + id);

            await _unitOfWork.Customers.UpdateAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _unitOfWork.Customers.DeleteAsync(customer);
            return NoContent();
        }
    }
}
