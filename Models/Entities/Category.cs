using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Webshop.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Category name length is 50 chars max")]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}