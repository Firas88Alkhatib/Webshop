using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Webshop.Models.Entities
{
    public class SellOrder : Order
    {
        public Address DeliveryAddresss { get; set; }

        [JsonIgnore]
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
    }
}