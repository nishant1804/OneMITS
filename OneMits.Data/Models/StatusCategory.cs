using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneMits.Data.Models
{
    public class StatusCategory
    {
        [Key]
        public int StatusCategoryId { get; set; }
        public string StatusCategoryTitle { get; set; }
        public virtual IEnumerable<Status> Status { get; set; }

    }
}

