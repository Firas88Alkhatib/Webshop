using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                await Initialize(scope.ServiceProvider);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private async static Task Initialize(IServiceProvider serviceProvider)
        {
            var Configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            //default roles
            var roles = Configuration.GetSection("DefaultValues:Roles").Get<string[]>().Select(role => new IdentityRole(role)).ToList();
            foreach (var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role.Name);
                if (!roleExist) await roleManager.CreateAsync(role);
            }
            //default admin
            var userName = Configuration["DefaultValues:Admin:UserName"];
            var password = Configuration["DefaultValues:Admin:Password"];
            var roleName = Configuration["DefaultValues:Admin:Role"];
            var userExist = await userManager.FindByNameAsync(userName);
            if (userExist == null)
            {
                ApplicationUser user = new() { UserName = userName };
                await userManager.CreateAsync(user, password);
                var x = await userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
