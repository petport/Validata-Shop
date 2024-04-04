using Microsoft.AspNetCore.Mvc;
using ValidataShopTest.Application.Commands;
using ValidataShopTest.Application.Queries;
using ValidataShopTest.DAL.Repositories;
using ValidataShopTest.Models;

namespace ValidataShopTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /*
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        */

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandHandler<CreateProductCommand> _createProductCommandHandler;
        private readonly IQueryHandler<GetProductQuery, Product> _getProductQueryHandler;


        public ProductsController(
            IUnitOfWork unitOfWork,
            ICommandHandler<CreateProductCommand> commandHandler,
            IQueryHandler<GetProductQuery, Product> getCustomerQueryHandler)
        {
            _unitOfWork = unitOfWork;
            _createProductCommandHandler = commandHandler;
            _getProductQueryHandler = getCustomerQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _unitOfWork.Products.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /*
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            var createdProduct = await _unitOfWork.Products.AddAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
        }
        */

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(CreateProductCommand command)
        {
            await _createProductCommandHandler.HandleAsync(command);
            return CreatedAtAction(nameof(GetProduct), new { id = command.Id }, command);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _unitOfWork.Products.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _unitOfWork.Products.DeleteAsync(product);
            return NoContent();
        }
    }
}
