using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Authentications_TEST.Models
{
    public class Employees
    {
        [Key]
        public int EmplyeeId { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string LastName { get; set; }
    }
}
