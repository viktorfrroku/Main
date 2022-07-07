using System;

namespace Authentications_TEST.Models.shppingCardModels
{
    public class discount
    {
        public int Id { get; set; }
        public string description { get; set; }
        public decimal discount_percent     { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime deleted_at { get; set; }
    }
}
