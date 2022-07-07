using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Authentications_TEST.Models
{
    public class Courses
    {
        
        public int CoursesId { get; set; }
        [Required]
        [Display(Name="Course Name")]
        public string CoursesName { get; set; }
        }
}
