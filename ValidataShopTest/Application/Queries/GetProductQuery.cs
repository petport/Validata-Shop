namespace ValidataShopTest.Application.Queries
{
    public class GetProductQuery
    {
        public int ProductId { get; set; }

        public GetProductQuery(int id)
        {
            ProductId = id;
        }
    }
}