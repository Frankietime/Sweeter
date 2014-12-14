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
        UsersContext db = new UsersContext();

        public UserProfile SelectUser()
        {
            var SelectUser = (from u in db.UserProfiles
                              where u.UserName == User.Identity.Name
                              select u).First();
            return SelectUser;
        }
        public ActionResult Index()
        {            
            ViewBag.Message = "Social Network";
           
            var order = from p in db.UserPosts
                        orderby p.DateTime
                        select p;
            return View(order);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Sweeter is a social network";

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

            // Rutina para mostrar los ultimos posts        TODO: Agregar limite de visualizacion
            var CurrentUser = SelectUser();
            
            var user = (from u in db.UserProfiles
                       where u.UserName == User.Identity.Name
                       select u.UserId).First();


            var model = from p in db.UserPosts
                        where p.UserName == User.Identity.Name
                        select p;
            
           var FriendsIdentity = from f in db.Friends
                                  where f.UserId == user
                                  select f;
           List<IQueryable<UserPost>> list = new List<IQueryable<UserPost>>();
            foreach(var f in FriendsIdentity)
            {
               var friendpost = from p in db.UserPosts
                           where p.UserId == f.RelationshipId
                           select p;
               list.Add(friendpost);
            }

            foreach(var p in list)
            {
                model = model.Concat(p);
            }
            ViewBag.count = model.Count();

            string legend = (from p in db.Profiles
                             where p.UserId == CurrentUser.UserId
                             select p.Legend).First();

            ViewBag.CurrentLegend = legend;

            string photo = (from p in db.Profiles
                            where p.UserId == CurrentUser.UserId
                            select p.PhotoPath).First();
            ViewBag.CurrentPhotoPath = photo;

            return View(model.ToList());

            
        }

        [Authorize]
        public ActionResult SearchFriends(string search = null)
        {
            var SelectUser = (from u in db.UserProfiles
                             where u.UserName == User.Identity.Name
                             select u).First();
            var SearchQuery = from s in db.UserProfiles
                              where s.UserName.StartsWith(search) & s.UserName != User.Identity.Name
                              select s;


            // Filtro de Usuarios ya agregados
            
            var CurrentFriends = from c in db.Friends
                                 where c.UserId == SelectUser.UserId
                                 select c;
            List<IQueryable<UserProfile>> list = new List<IQueryable<UserProfile>>();
            foreach(var c in CurrentFriends)
            {
                var UpdateQuery = from i in db.UserProfiles
                                  where i.UserId == c.RelationshipId
                                  select i;
                list.Add(UpdateQuery);
            }
            foreach(var l in list)
            {
                SearchQuery = SearchQuery.Except(l);
            }

            return View(SearchQuery);
        
        }
         [Authorize]
         public ActionResult AddFriend(int friend)
            {

            var SelectFriend = (from f in db.UserProfiles
                                    where f.UserId == friend
                                    select f).First();
            
            var SelectUser = (from u in db.UserProfiles
                             where u.UserName == User.Identity.Name
                             select u).First();
         
            Friend Friend = new Friend { UserId = SelectUser.UserId, RelationshipId = SelectFriend.UserId };
            db.Friends.Add(Friend);
            db.SaveChanges();
            
            return View(SelectFriend);/*Falta insertar Friend, indicar en l 
                               * impedir la re adicion del mismo usuario*/
        }
        [Authorize]
        public ActionResult SweetPosts(string SweetTitle, string SweetContent)
         {
            var CurrentId = (from u in db.UserProfiles
                         where u.UserName == User.Identity.Name
                         select u.UserId).First();
             UserPost SweetPost = new UserPost { UserName = User.Identity.Name, UserId = CurrentId, Title = SweetTitle, Text = SweetContent, DateTime = DateTime.Now };
             db.UserPosts.Add(SweetPost);
             db.SaveChanges();
             return RedirectToAction("Sweet", "Home");
         }
       

        }
    }
