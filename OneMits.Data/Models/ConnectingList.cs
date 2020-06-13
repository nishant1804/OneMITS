using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OneMits.Data.Models
{
    public class ConnectingList
    {
        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
        public string Status { get; set; }
    }
}
