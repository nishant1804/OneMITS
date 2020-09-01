using EtherealMade.Models.Category;
using EtherealMade.Models.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtherealMade.Models.Home
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }
        public string IpAddress { get; set; }
        public IEnumerable<QuestionListingModel> RecentQuestion { get; set; }
        public IEnumerable<QuestionListingModel> PopularQuestion { get; set; }
        public IEnumerable<QuestionListingModel> MostResponseQuestion { get; set; }
        public IEnumerable<QuestionListingModel> PriorityQuestion { get; set; }

    }
}
