using OneMits.Models.ApplicationUser;
using OneMits.Models.Status;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Status
{
    public class AddStatusModel
    {
        public string StatusCategoryTitle { get; set; }
        public int StatusCategoryId{get; set;}
        public string StatusTitle { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int StatusId { get; set; }
        public IEnumerable<StatusCategory.StatusCategoryListingModel> StatusCategory { get; set; }
        public IEnumerable<ProfileModel> UserList { get; set; }

    }
}
