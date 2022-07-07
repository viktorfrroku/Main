using Authentications_TEST.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentications_TEST.services
{
    
    public class JwtTokenHandler
    {
        public readonly IConfiguration _configuration;
        public JwtTokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(ApplicationUser user, string role)
        {
            var jwtConfig = _configuration.GetSection("JWT");


            var sercretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["key"]));
            var cridentials = new SigningCredentials(sercretKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
               new Claim(ClaimTypes.Role,role)
            };

            var token = new JwtSecurityToken(
                issuer: jwtConfig["Issuer"],
                audience: jwtConfig["Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(jwtConfig["DurationInMinutes"])),
                signingCredentials: cridentials
                );

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }
    }
}
