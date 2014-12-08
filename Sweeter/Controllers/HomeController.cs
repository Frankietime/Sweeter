using Sweeter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sweeter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            ViewBag.Message = "Social Network";
            var db = new UsersContext();
            var order = from p in db.Posts
                        orderby p.DateTime
                        select p;
            return View(order);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Sweeter is a social network simile to Tweeter, but with fewer people in it (by now)";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page";

            return View();
        }

        [Authorize]
        public ActionResult Sweet()
        {
            ViewBag.Search = View("SearchFriends");
            var db = new UsersContext();
            
            var user = from u in db.UserProfiles
                       where u.UserName == User.Identity.Name
                       select u;

            int UserIdentity = 0;
            foreach(var u in user)
            {
                UserIdentity = u.UserId;
                
            }
            var Userposts = from p in db.Posts
                        where p.UserId == UserIdentity
                        select p;

            
            var FriendsIdentity = from f in db.Friends
                                  where f.UserId == UserIdentity
                                  select f.RelationshipId;

           var querylist = new List<IQueryable<UserPost>>();
           var AllPosts = new List<UserPost>();

            foreach(var f in FriendsIdentity)
            {
               var FriendsPosts = from p in db.Posts
                           where p.UserId ==  f
                           select p;
               querylist.Add(FriendsPosts);
            }

            foreach(var q in querylist)
            {
                foreach(var h in q)
                {
                    AllPosts.Add(h);
                }
            }

          
           foreach (var u in Userposts)
           {
               AllPosts.Add(u);
           }
            List<UserPost> PostList = AllPosts.OrderBy(o => o.DateTime).ToList();
            ViewBag.List = PostList;
            return View();

            
        }

    [Authorize]
        public ActionResult SearchFriends(string ReturnUrl)
        {
            return View();
        }


    }
}
