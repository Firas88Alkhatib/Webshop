using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class OrderItem : Product
    {
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal ProductPrice { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal TotalPrice => Quantity * ProductPrice;
    }
}
