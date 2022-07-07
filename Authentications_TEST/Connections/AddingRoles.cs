using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace Authentications_TEST.Connections
{
    public  class AddingRolesSeed
    {
        // public readonly static 
       // public static IHostEnvironment hostEnvironmet;
        
        public static void addroles(IServiceProvider serviceProvider) {
            using (var scope = serviceProvider.CreateScope())
            {
                var context1 = scope.ServiceProvider.GetRequiredService<DBConnection>();
                //var roleManager = scope.ServiceProvider.GetServices<RoleManager>();
               // var context = serviceProvider.GetRequiredService<DBConnection>();

                string[] roles = new string[] { "SuperAdmin", "Admin", "Manager", "Employee", "User", "Customer", "Client" };
                foreach (string role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(context1);

                    if (!context1.Roles.Any(r => r.Name == role))
                    {
                        roleStore.CreateAsync(new IdentityRole(role) { NormalizedName = role.ToUpper()});
                    }
                }
            }
             
        }
    }
}
