using System;
using System.Collections.Generic;
using System.Text;

namespace EtherealMade.Data.Models
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryExtraDescription { get; set; }
        public string CategoryImageUrl { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
