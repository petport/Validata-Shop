namespace ValidataShopTest.Application.Commands
{
    public class CreateProductCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public CreateProductCommand(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}