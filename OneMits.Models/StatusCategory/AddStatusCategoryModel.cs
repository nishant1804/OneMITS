using OneMits.Models.ApplicationUser;
using OneMits.Models.Status;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.StatusCategory
{
    public class AddStatusCategoryModel
    {
        public int StatusCategoryId { get; set; }
        public string StatusCategoryTitle { get; set; }
        public IEnumerable<StatusListingModel> Status { get; set; }
        public IEnumerable<ProfileModel> UserList { get; set; }
    }
}
