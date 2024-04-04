using ValidataShopTest.DAL.Repositories;

public interface IUnitOfWork : IDisposable
{
    ICustomerRepository Customers { get; }
    IOrderRepository Orders { get; }
    IProductRepository Products { get; }
    Task<int> CompleteAsync();
}