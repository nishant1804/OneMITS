using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.ApplicationUser
{
    public class ConnectModel
    {
        public int Id { get; set; }
        public string UserId1 { get; set; }
        public string UserId2 { get; set; }
        public string Status { get; set; }
    }
}
