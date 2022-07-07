using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentications_TEST.Models.shppingCardModels
{
    public class shopping_session
    {
        public int id { get; set; }
        [ForeignKey("user")]
        public string _user_id { get; set; }
        public decimal total  { get; set; }
        public DateTime created_at { get; set; }
        public ApplicationUser user     { get; set; }
    }
}
