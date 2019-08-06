using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using NT_Project.Models;
using NT_Project.ViewModels;

namespace NT_Project.Controllers
{
    public class PostController : Controller
    {
        Logic Logic = new Logic();
        ApplicationDbContext context = new ApplicationDbContext(); 
        public ActionResult Index()
        {
            //var posts = Logic.GetFriendsPosts(User.Identity.GetUserId());
            var posts = context.Posts.ToList();
            return View("~/Views/Post.cshtml",posts);
        }



    }
}