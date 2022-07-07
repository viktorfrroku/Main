using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentications_TEST.Models
{
    public class UserJwtToken
    {
        [Key]
        public int token_id { get; set; }
        public string username { get; set; }
        public string AuthToken { get; set; }
    }
}
