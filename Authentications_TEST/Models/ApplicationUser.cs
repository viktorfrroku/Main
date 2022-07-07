using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentications_TEST.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Required]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }
        //[Required]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }
       // [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
       // [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        }
             
    
}
