using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Sweeter.Models;

namespace Sweeter.Models
{
    public class UserPost
    {
        [Key]
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public UserMultimedia[] Multimedias { get; set; }
        public Favourite[] Favourites { get; set; }
        public Resweet[] Resweets { get; set; }
        public string DateTime { get; set; }
    }  
    public class Favourite // Se inserta en el array Favourites del objeto UserPost
    {
        [Key]
        public int FavouriteId { get; set; }
        public int FromUserId { get; set; }
    }
    public class Resweet // Se inserta en el array Resweets del objeto UserPost
    {
        [Key]
        public int ResweetId { get; set; }
        public int FromUserId { get; set; }
    }
    /*public class UniversalPost
  {
      [Key]
      public string UniversalPostId { get; set; } 
      public int UserId { get; set; }
      public int PostId { get; set; }
      public string DateTime { get; set; }
  }*/
}