using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentications_TEST.Models;
using Authentications_TEST.Models.shppingCardModels;

namespace Authentications_TEST.Connections
{
    public class DBConnection : IdentityDbContext<IdentityUser>
    {
        public DBConnection(DbContextOptions<DBConnection> options) : base(options)
        { 
        }
        public DbSet<Employees> employees { get; set; }
        public DbSet<ApplicationUser> applicationUser { get; set; }
        public DbSet<IdentityRole> identityRole { get; set; }
        public DbSet<Courses> courses { get; set; }
        public DbSet<Students> students { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        public DbSet<UserJwtToken> userJwtToken { get; set; }

        public DbSet<product_category> product_category { get; set; }
        public DbSet<product> product{ get; set; }
        public DbSet<discount> discount { get; set; }    


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);

            builder.Entity<Courses>().HasData(
                  new Courses { CoursesId = 1, CoursesName = "Algebra" },
                  new Courses { CoursesId = 2, CoursesName = "Academic Writing" },
                  new Courses { CoursesId = 3, CoursesName = "Humannities" },
                  new Courses { CoursesId = 4, CoursesName = "Applied Art" },
                  new Courses { CoursesId = 5, CoursesName = "Art History" }
                );
            builder.Entity<IdentityRole>().HasData(new List<IdentityRole> {

               new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "SuperAdmin"},
               new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin"},
               new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Manager"},
               new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Customer"},
               new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User"}
            }
          );
        }
        
    }
}
