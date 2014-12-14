using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sweeter.Models
{   
     public class UserMultimedia
    {
        [Key]
        public int UserId { get; set; }
        public string PhotoPath { get; set; }
        public string Legend { get; set; }
    }
}