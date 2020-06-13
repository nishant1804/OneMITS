using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneMits.Data.Models
{
    public class ReportQuestion
    {
        [Key]
        public int Id { get; set; }
        public virtual Question Question { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
