using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentications_TEST.Models.shppingCardModels
{
    public class product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string SKU { get; set; }
        [ForeignKey("product_Category")]
        public int category_id { get; set; }
        [ForeignKey("product_Inventory")]
        public int inventory_id { get; set; }
        public decimal price { get; set; }
        [ForeignKey("discount")]
        public int? discount_id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime created_at { get; set; }

        public product_category product_Category { get; set; }
        public product_inventory product_Inventory { get; set; }
        public discount discount { get; set; }
        }
}
