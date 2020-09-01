using EtherealMade.Models.ApplicationUser;
using EtherealMade.Models.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtherealMade.Models.Search
{
    public class SearchModel
    {
        public IEnumerable<QuestionListingModel> Questions { get; set; }
        public IEnumerable<ProfileModel> UserList { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchResults { get; set; }
    }
}
