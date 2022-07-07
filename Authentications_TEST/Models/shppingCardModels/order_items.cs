using System;

namespace Authentications_TEST.Models.shppingCardModels
{
    public class order_items
    {
        public int CategoryId { get; set; }
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int quntity  { get; set; }
        public DateTime created_at { get; set; }
    }
}
