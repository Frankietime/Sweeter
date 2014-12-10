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
        public int UserMultimediaId { get; set; }
        public int UserId { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}