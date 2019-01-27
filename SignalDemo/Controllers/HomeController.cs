using Microsoft.AspNet.Identity;
using SignalDemo.DbModels;
using SignalDemo.Models;
using SignalDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var userId =Convert.ToInt32(User.Identity.GetUserId());
            var Friends= db.Friends.Where(x => x.UserId1 == userId).ToList();
            ChatModel model = new ChatModel();
            model.Friends = Friends;


            return View(model);
        }
        public ActionResult GetMessages(int FriendId)
        {
            var userId = Convert.ToInt32(User.Identity.GetUserId());
            ApplicationDbContext db = new ApplicationDbContext();
           var Messages= db.Messages.Where(x => x.FromUserId == userId && x.ToUserId == FriendId || x.FromUserId == FriendId && x.ToUserId == userId).ToList();
            return PartialView("~/Views/Shared/_Chatting.cshtml", Messages);
        }
        public ActionResult SaveMessages(int FriendId,string Messages)
        {
            var userId = Convert.ToInt32(User.Identity.GetUserId());
            ApplicationDbContext db = new ApplicationDbContext();
            Message msg = new Message();
            msg.FromUserId = userId;
            msg.ToUserId = FriendId;
            msg.Messages = Messages;
            msg.SentDate = DateTime.Now;
            db.Messages.Add(msg);
            db.SaveChanges();
            var Messagess = db.Messages.Where(x => x.FromUserId == userId && x.ToUserId == FriendId || x.FromUserId == FriendId && x.ToUserId == userId).ToList();
            return PartialView("~/Views/Shared/_Chatting.cshtml", Messagess);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}