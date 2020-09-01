using System;
using System.Collections.Generic;
using System.Text;

namespace EtherealMade.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductSubTitle { get; set; }
        public string ProductImage { get; set; }
        public string ProductPrice { get; set; }
        public string ProductWeight { get; set; }
        public string ProductDesciption { get; set; }
        public string ProductThemeColour { get; set; }
        public string CheckoutLink { get; set; }
        public string Module1Title { get; set; }
        public string Module1Description { get; set; }
        public string Module1Image { get; set; }


        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
