using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Webshop.Models;
using Webshop.Models.Entities;

namespace Webshop.Services
{
    

    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtConfig jwtConfig;
        

        public AuthenticationService(JwtConfig jwtConfig)
        {
            this.jwtConfig = jwtConfig;
        }

        public string GenerateAccessToken(ApplicationUser user,List<string> userRoles)
        {
            var jwtSecterKey = Encoding.ASCII.GetBytes(jwtConfig.SecretKey);
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim("Id", user.Id),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            });
            userRoles.ForEach(role => claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role)));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtSecterKey), SecurityAlgorithms.HmacSha512Signature)
            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var accessToken = jwtTokenHandler.WriteToken(token);
            return accessToken;
        }

        public Refreshtoken GenerateRefreshToken(string token)
        {
            var principal = GetClaimsFromExpiredToken(token);
            var jti = principal.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            var userId = principal.Claims.SingleOrDefault(x => x.Type == nameof(ApplicationUser.Id)).Value;
            var refreshToken = new Refreshtoken()
            {
                JwtId = jti,
                UserId = userId,
                CreateDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(jwtConfig.RefreshTokenExpiryInMonths),
                Token = GenerateRandomString() + Guid.NewGuid()
            };
            return refreshToken;
        }

        public ClaimsPrincipal GetClaimsFromExpiredToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals("HS512", StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

        public string GenerateRandomString(int length = 32)
        {
            var random = new byte[length];
            using (var randomGenerator = RandomNumberGenerator.Create())
            {
                randomGenerator.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
    }
}