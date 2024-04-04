namespace ValidataShopTest.Application.Commands
{
    public class CreateCustomerCommand
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }

        public CreateCustomerCommand(string firstName, string lastName, string address, string postalCode)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PostalCode = postalCode;
        }

    }
}