using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(100,ErrorMessage = "Product name length is 100 chars max")]
        public string Name { get; set; }

        [StringLength(400,ErrorMessage = "Product description length is 100 chars max")]
        public string Description { get; set; }

        public List<Image> Images { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public List<Category> Categories { get; set; }
    }
}
