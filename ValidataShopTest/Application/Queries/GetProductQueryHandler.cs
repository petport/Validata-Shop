using ValidataShopTest.Application.Queries;
using ValidataShopTest.Models;

namespace ValidataShopTest.Application.Queries
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, Product>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> HandleAsync(GetProductQuery query)
        {
            return await _unitOfWork.Products.GetByIdAsync(query.ProductId);
        }
    }
}
