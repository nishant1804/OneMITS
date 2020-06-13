using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneMits.Data.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusTitle { get; set; }
        public DateTime StatusCreated { get; set; }
        public int NumberViews { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
