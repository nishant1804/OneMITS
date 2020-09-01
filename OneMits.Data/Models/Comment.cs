using System;
using System.Collections.Generic;
using System.Text;

namespace EtherealMade.Data.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentCreated { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public virtual Product Product { get; set; }
    }
}
