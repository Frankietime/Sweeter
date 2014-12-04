using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sweeter.Models
{
    public class Profile
    {
        public int UserProfileId { get; set; }
        public Friend[] Friends { get; set; }
        public UserMultimedia ProfilePhoto { get; set; }
        public string Legend { get; set; }
    }
    public class Friend
    {
        public int UserFriendId { get; set; }
        public int UserId { get; set; }
    }
}