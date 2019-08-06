using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.VisualBasic.ApplicationServices;
using NT_Project.Models;
using NT_Project.ViewModels;

namespace NT_Project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        Logic Logic = new Logic();

        public ActionResult Index()
        {
            return View(new postViewModel{posts = Logic.GetFriendsPosts(User.Identity.GetUserId())});
        }

        [HttpPost]
        public ActionResult SearchResult(string required)
        {
            TempData["Text"] = "Send Request";
            TempData["Action"] = "SendRequest";
            TempData["Controller"] = "Home";
            var res = Logic.SearchAccount(required, User.Identity.GetUserId());
            return View("~/Views/Shared/_RelationsLayout.cshtml", res);
           
        }

        [HttpPost]
        public ActionResult AddPost(postViewModel Post)
        {
            if (Post.content != null && Post.text != null)
            Logic.AddPost(User.Identity.GetUserId(), Post.text, Post.content);
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult SendRequest(string id)
        {
            Logic.AddRelation(User.Identity.GetUserId(), id, 1);
            return Index();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}