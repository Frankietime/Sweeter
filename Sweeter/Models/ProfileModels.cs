using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sweeter.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Friend[] Friends { get; set; }
        public string PhotoPath { get; set; }
        public string Legend { get; set; }
    }
    public class Friend
    {
        public int FriendId { get; set; } // Esta es la PK de la tabla, no el Id del amigo del UserId
        public int UserId { get; set; }
        public int RelationshipId { get; set; } // Este es el Id del User amigo del UserId
    }
}