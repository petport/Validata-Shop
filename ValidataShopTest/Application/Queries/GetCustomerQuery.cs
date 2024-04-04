namespace ValidataShopTest.Application.Queries
{
    public class GetCustomerQuery
    {
        public int CustomerId { get; set; }

        public GetCustomerQuery(int id)
        {
            CustomerId = id;
        }
    }
}
