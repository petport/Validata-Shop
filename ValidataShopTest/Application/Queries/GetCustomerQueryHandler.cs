using ValidataShopTest.Models;

namespace ValidataShopTest.Application.Queries
{
    public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, Customer>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Customer> HandleAsync(GetCustomerQuery query)
        {
            return await _unitOfWork.Customers.GetByIdAsync(query.CustomerId);
        }
    }
}
