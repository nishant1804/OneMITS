using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EtherealMade.Data.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string notification { get; set; }
        public DateTime DateTime { get; set; }
        public virtual ApplicationUser UserFrom { get; set; }
        public virtual ApplicationUser UserTo { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ActionId { get; set; }
        public bool Status { get; set; } = false;
    }
}
