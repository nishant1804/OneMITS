using EtherealMade.Models.Category;
using EtherealMade.Models.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtherealMade.Models.Status
{
    public class StatusIndexModel
    {
        public IEnumerable<StatusListingModel> StatusList { get; set; }
        public string SearchQuery { get; set; }
    }
}
