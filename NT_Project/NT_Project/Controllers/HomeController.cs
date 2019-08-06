using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NT_Project.Models;

namespace NT_Project.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private string AfterActionView = "~/Views/Home/Index.cshtml";

        Logic Logic = new Logic();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false) return View("About");
            return View("~/Views/Post.cshtml",Logic.GetFriendsPosts(User.Identity.GetUserId()));
        }

        [HttpPost]
        public ActionResult Index(string required)
        {
            TempData["Text"] = "Send Request";
            TempData["Action"] = "SendRequest";
            TempData["Controller"] = "Home";
            return View("~/Views/Shared/_RelationsLayout.cshtml", Logic.SearchAccount(required,User.Identity.GetUserId()));
           
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult SendRequest(string id)
        {
            Logic.AddRelation(User.Identity.GetUserId(), id, 1);
            return View(AfterActionView);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}