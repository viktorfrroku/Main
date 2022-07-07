using Authentications_TEST.Connections;
using Authentications_TEST.Controllers;
using Authentications_TEST.Models;
using Authentications_TEST.services;
using Authentications_TEST.services.IRepositories;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentications_TEST
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddCors(o => o.AddPolicy(name: MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000",
                        "http://localhost:3001",
                        "http://localhost:3002/"
                        //"https://localhost:44353/Download/uplFile"
                        )
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .AllowCredentials(); 
                }));
            //services.AddCors(o => o.AddPolicy("CorsPolicy", 
            //    builder => builder.AllowCredentials()
            //    .AllowAnyHeader()
            //    .AllowAnyOrigin()
            //    .Build()
            //));


            services.AddControllers();
            services.AddDbContext<DBConnection>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DbConnections"))
                ;
            })
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DBConnection>()
                .AddDefaultTokenProviders();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IEmployeesRepository, EmployeesRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
           // services.AddScoped<DBConnection>();

            services.AddScoped<JwtTokenHandler>();
            services.AddTransient<DBConnection>();

            services.AddSingleton(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "testBook1.xlsx"));
            services.AddSingleton(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), $"outputdata-{DateTime.Now.ToFileTime()}.csv"));


            services.AddDistributedMemoryCache();
            services.AddSession(
                //options =>
          //  {
            //    options.IdleTimeout = TimeSpan.FromMinutes(60);//We set Time here 
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //}
            );


            var JwtConfig = Configuration.GetSection("JWT");

            services.AddAuthentication(x => {

                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuer = false,
                    ValidIssuer = JwtConfig["key"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConfig["key"])),
                    ValidAudience = JwtConfig["Audience"],
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)

                };
            });
            services.AddAuthorization(o =>
            {
                o.AddPolicy("RequireCustomer", policy =>
                    policy.RequireRole("Customer"));               
                o.AddPolicy("RequireManager", policy =>
                    policy.RequireRole("Manager", "Customer"));
                o.AddPolicy("RequireAdministrator", policy =>
                   policy.RequireRole("Administrator", "Manager", "Customer"));


            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseRouting();

          
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //   SampleData.Initialize(app.ApplicationServices);

            //AddingRolesSeed.addroles(app.ApplicationServices);

        }

       
    }
}
