using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.StatusCategory
{
    public class StatusCategoryIndexModel
    {
        public IEnumerable<StatusCategoryListingModel> StatusCategoryList { get; set; }
        public StatusCategoryListingModel StatusCategory { get; set; }
        public string AuthorName { get; set; }
    }
}
