using System;
using System.ComponentModel.DataAnnotations;

namespace Authentications_TEST.Models.shppingCardModels
{
    public class product_category
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime created_at { get; set; }
    }
}
