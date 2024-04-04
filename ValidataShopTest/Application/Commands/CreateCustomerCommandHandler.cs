using ValidataShopTest.Models;

namespace ValidataShopTest.Application.Commands
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(CreateCustomerCommand command)
        {
            var customer = new Customer
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Address = command.Address,
                PostalCode = command.PostalCode
            };

            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.CompleteAsync();
        }
    }
}
