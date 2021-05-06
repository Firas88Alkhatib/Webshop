using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models.Entities
{
    public class OrderItem : Product
    {
        public int Quantity { get; set; } = 0;

        [Column(TypeName = "decimal(8, 2)")]
        public decimal ProductPrice { get; set; } = 0;
        [Column(TypeName = "decimal(12, 2)")]
        public decimal TotalPrice => Quantity * ProductPrice;
    }
}
