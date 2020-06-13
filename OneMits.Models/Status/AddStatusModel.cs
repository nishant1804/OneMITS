using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Status
{
    public class AddStatusModel
    {
        public string StatusTitle { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int StatusId { get; set; }
    }
}
