using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentications_TEST.Models
{
    public class Address
    {
        [Key]
        public int addressId { get; set; }
        public string Land { get; set; }
        public string City { get; set; }
        public string street { get; set; }
        public int ZipCode { get; set; }
        public string Naeighberhood { get; set; }
    }
}
