using OneMits.Data.Models;
using OneMits.Models.Status;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.StatusCategory
{
    public class StatusCatogeryTopicModel
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int StatusCategoryId { get; set; }
        public int StatusCategoryTitle { get; set; }
        public IEnumerable<Data.Models.StatusCategory> StatusCategory { get; set; }
        public Data.Models.StatusCategory StatusCategoryDrop { get; set; }
        public IEnumerable<StatusListingModel> Status { get; set; }
        public string SearchQuery { get; set; }
    }
}
