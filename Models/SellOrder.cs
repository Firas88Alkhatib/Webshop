using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Webshop.Models
{
    public class SellOrder : Order
    {
        public Address DeliveryAddresss { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ApplicationUser User { get; set; }

        public int UserId { get; set; }
    }
}