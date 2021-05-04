using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Webshop.Models
{
    public class Order
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DeliveryDate { get; set; }

        public Boolean Delivered { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal TotalOrderPrice => OrderItems.Sum(item => item.TotalPrice);
    }
}