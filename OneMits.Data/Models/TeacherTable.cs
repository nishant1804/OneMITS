using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EtherealMade.Data.Models
{
    public class TeacherTable
    {
        [Key]
        public string EnrollmentNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
    }
}
