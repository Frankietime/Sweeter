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
        public string PhotoPath { get; set; }
        public string Legend { get; set; }
        public bool PendingRequests { get; set; }
    }
    public class Friend
    {
        public int FriendId { get; set; } 
        public int UserId { get; set; }
        public int RelationshipId { get; set; } 
    }
    public class FriendRequest
    {
        public int FriendRequestId { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
    }
        
}