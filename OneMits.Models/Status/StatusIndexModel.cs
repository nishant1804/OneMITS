using OneMits.Models.Category;
using OneMits.Models.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Status
{
    public class StatusIndexModel
    {
        public IEnumerable<StatusListingModel> StatusList { get; set; }
        public string SearchQuery { get; set; }
    }
}
