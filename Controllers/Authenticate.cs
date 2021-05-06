using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webshop.Models;
using Webshop.Models.Dto;
using Webshop.Services;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authenticate : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ApplicationUserManager userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public Authenticate(
            IAuthenticationService authenticationService,
            ApplicationUserManager userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.authenticationService = authenticationService;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await userManager.FindByNameAsync(loginDto.Username);
            if(user == null)
            {
                return BadRequest();
            }
            var correctPassword = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!correctPassword)
            {
                return BadRequest();
            }
            var roles = await userManager.GetRolesAsync(user);
            var AccessToken = authenticationService.GenerateAccessToken(user,(List<string>)roles);
            return Ok(AccessToken);
        }
    }
}