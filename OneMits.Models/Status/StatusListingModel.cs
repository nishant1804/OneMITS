using EtherealMade.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtherealMade.Models.Status
{
    public class StatusListingModel
    {
        public int StatusId { get; set; }
        public string StatusTitle { get; set; }
        public DateTime StatusCreated { get; set; }

        public int NumberView { get; set; }

        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
