using System.Text.Json.Serialization;

namespace Webshop.Models.Entities
{
    public class BuyOrder : Order
    {
        [JsonIgnore]
        public Supplier Supplier { get; set; }

        public int SupplierId { get; set; }
        public string InvoiceNumber { get; set; }
    }
}