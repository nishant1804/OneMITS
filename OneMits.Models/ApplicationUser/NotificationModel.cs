using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.ApplicationUser
{
    public class NotificationModel
    {
        
        public int Id { get; set; }
        public string notification { get; set; }
        public DateTime DateTime { get; set; }
        public string UserFrom { get; set; }
        public string UserTo { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ActionId { get; set; }
        public bool Status { get; set; }
    }
}
