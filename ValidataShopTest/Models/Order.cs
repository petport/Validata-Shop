using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidataShopTest.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal TotalPrice { get; set; }


        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        
        //public IEnumerable<object>? OrderItems { get; internal set; }

        //public Customer? Customer { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
