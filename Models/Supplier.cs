using System.ComponentModel.DataAnnotations;

namespace Webshop.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Address Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}