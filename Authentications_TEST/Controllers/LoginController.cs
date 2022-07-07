using Authentications_TEST.Connections;
using Authentications_TEST.Models;
using Authentications_TEST.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ubiety.Dns.Core;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Authentications_TEST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase

    {
        //link here https://docs.microsoft.com/en-us/aspnet/core/security/authentication/add-user-data?view=aspnetcore-5.0&tabs=visual-studio
        //link here https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-5.0&tabs=visual-studio
        //link here https://social.technet.microsoft.com/wiki/contents/articles/37797.asp-net-identity-customize-user-authentication.aspx
        //link here https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-5.0&tabs=visual-studio
        //link here https://www.tektutorialshub.com/asp-net-core/jwt-authentication-in-asp-net-core/
        //link here https://www.youtube.com/watch?v=l56YLbAVAfo


        public readonly DBConnection _context;
        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signinManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public JwtTokenHandler _jwtTokenHandler;
        // GET: LoginController
        public LoginController(
            DBConnection context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            JwtTokenHandler jwtTokenHandler)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signInManager;
            _roleManager = roleManager;
            _jwtTokenHandler = jwtTokenHandler;

        }


        //***CREATING ROLES TO USER

        [HttpPost("AddRoles")]
        public async Task<IActionResult> CreateRoles(IdentityRole roles)
        {
            IdentityRole role = new IdentityRole
            {
                Name = roles.Name
            };

            var result = await _roleManager.CreateAsync(new IdentityRole(role.Name));


            if (result.Succeeded)
                return Ok();


            return BadRequest(new { message = result.Errors.ToList() });
        }




        //REGISTER USER

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(ApplicationUser userModel)
        {
            IdentityUser user = new IdentityUser
            {

                UserName = userModel.UserName,
                Email = userModel.Email
            };



            // user.PasswordHash = userModel.Password;
            // var hashedPassword = userpassword.Ha

            // var FoundUser = await _userManager.FindByNameAsync(user.UserName);
            // if (FoundUser == null)

            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (result.Succeeded)
            {
                //var roleName = await _roleManager.FindByNameAsync("Customer");
                await _userManager.AddToRoleAsync(user, "Admin");
                return Ok();

            }

               



            return BadRequest(new { message = result.Errors.ToList() });



        }

        //LOGIN USER WITH JWT
        [HttpPost("Login")]
        public async Task<IActionResult> Login(ApplicationUser users)
        {

            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = users.UserName
                };


                var userFromDB = await _userManager.FindByNameAsync(user.UserName);

                SignInResult result = await _signinManager.CheckPasswordSignInAsync(userFromDB, users.Password, false);
                if (result.Succeeded)
                {
                    await _signinManager.SignInAsync(user, true);

                    var role = await _roleManager.FindByNameAsync("Admin");

                    var tokenstr = _jwtTokenHandler.GenerateToken(users, role.Name);
                    UserJwtToken userToken = new UserJwtToken
                    {
                        username = user.UserName,
                        AuthToken = tokenstr
                    };

                   // _context.userJwtToken.Add();
                    return Ok(new { token = tokenstr } );
                }
                else
                    return BadRequest(result);
            }


            // if (users.UserName == "" || users.Password == "")
            //    return BadRequest( "filds must be filled");

            else
                return BadRequest(ModelState.ErrorCount.ToString());

        }

        // [Authorize]
        //[HttpGet("Data")]
        //public List<Data> getData()
        //{
        //    List<Data> dt = new List<Data>();
        //    dt.Add(new Data { Id = 2, name = "saw", description = "for wood usage" });
        //    dt.Add(new Data { Id = 2, name = "rod", description = "linear messurment" });
        //    dt.Add(new Data { Id = 2, name = "mask", description = "for protection" });

        //    return dt;
        //}




        // AUTHENTICATE USER WITH JWT


        [HttpGet("error")]
        public string errorpage()
        {
            string errorname = "there is an error in the system";
            return errorname;
        }
        [HttpGet("success")]
        public string successPage()
        {
            string successPage = "success....";
            return successPage;
        }



    }
}


