using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string StreetName { get; set; }
        public string Building { get; set; }
    }
}
