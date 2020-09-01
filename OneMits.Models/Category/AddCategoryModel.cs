using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtherealMade.Models.Category
{
    public class AddCategoryModel
    {
        public string CategoryTitle { get; set; }
        public string CategoryDescription { get; set; }
    }
}
