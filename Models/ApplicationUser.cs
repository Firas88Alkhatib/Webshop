using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Webshop.Models.Entities;

namespace Webshop.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Refreshtoken Refreshtoken { get; set; }
        public List<SellOrder> Orders { get; set; }
    }
}