using System;

namespace Authentications_TEST.Models.shppingCardModels
{
    public class order_details
    {
        public int id { get; set; }
        public string _user_id { get; set; }
        public decimal total { get; set; }
        public int payment_id { get; set; }
        public DateTime created_at { get; set; }
    }
}
