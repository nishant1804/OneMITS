using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EtherealMade.Data.Models
{
    public class ReportAnswer
    {
        [Key]
        public int Id { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
