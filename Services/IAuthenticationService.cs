using System.Collections.Generic;
using System.Security.Claims;
using Webshop.Models;
using Webshop.Models.Entities;

namespace Webshop.Services
{
    public interface IAuthenticationService
    {
        public string GenerateAccessToken(ApplicationUser user, List<string> userRoles);

        public Refreshtoken GenerateRefreshToken(string token);

        public ClaimsPrincipal GetClaimsFromExpiredToken(string token);
    }
}