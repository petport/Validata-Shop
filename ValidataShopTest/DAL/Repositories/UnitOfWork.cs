namespace ValidataShopTest.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ValidataShopContext _context;
        public ICustomerRepository Customers { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IProductRepository Products { get; private set; }


        public UnitOfWork(ValidataShopContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Products = new ProductRepository(_context);
            Orders = new OrderRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
             return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
