using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Authentications_TEST.Models
{
    
    public class Students {
        [Key]
              
        public int studentsId { get; set; }
        [Required]
        [Display(Name ="FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Courses")]
        public ICollection<Courses> Courses{ get; set; }
        public ICollection<Address> Addresses { get; set; }
        public Enrollment enrollment { get; set; }
        public string Profile_image { get; set; }
    }
}
