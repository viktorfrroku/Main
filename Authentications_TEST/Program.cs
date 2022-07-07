using Authentications_TEST.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authentications_TEST
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var builder = CreateHostBuilder(args).Build();

            using (var scope = builder.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                //using (var configuationDbContext = scope.ServiceProvider.GetRequiredService<CofigurationDbContext>())


                using (var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>())
                {

                    var user = new IdentityUser("doe@gmail.com")
                    {
                        Email = "doe@gmail.com"
                    };

                    userManager.CreateAsync(user, "Amos1245!").Wait();
                    userManager.AddClaimsAsync(user, new List<Claim> {

                   new Claim(ClaimTypes.Role, "SuperAdmin")

                  }).Wait();

                }

            }
            

            builder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
