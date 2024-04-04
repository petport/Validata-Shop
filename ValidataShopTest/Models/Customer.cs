using System.ComponentModel.DataAnnotations;
namespace ValidataShopTest.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? PostalCode { get; set; }


        //public ICollection<Order>? Orders { get; set; }

    }
}
