using OneMits.Models.Status;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneMits.Models.StatusCategory
{
    public class StatusCategoryListingModel
    {
        [Key]
        public int StatusCategoryId { get; set; }
        public string StatusCategoryTitle { get; set; }
        public virtual IEnumerable<StatusListingModel> Status { get; set; }
    }
}
