using ValidataShopTest.Application.Commands;
using ValidataShopTest.Models;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(CreateProductCommand command)
    {
        var product = new Product
        {
            Name = command.Name,
            Price = command.Price
        };

        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.CompleteAsync();
    }
}
