using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class JwtConfig
    {
        public string SecretKey { get; set; }
        public int TokenExipryInMinutes { get; set; }
        public int RefreshTokenExpiryInMonths { get; set; }
    }
}
