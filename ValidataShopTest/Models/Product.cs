﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidataShopTest.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        //public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
