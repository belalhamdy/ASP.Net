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
            var posts = Logic.GetFriendsPosts(User.Identity.GetUserId());
            return View("~/Views/Post.cshtml",posts);
        }

        public ActionResult ViewPost(string id)
        {
            var ret = Logic.GetPost(id);
            Interaction curr = new Interaction
            {
                ActionType = 1, ApplicationUser = Logic.GetUser(User.Identity.GetUserId()),
                ApplicationUserId = User.Identity.GetUserId(), Post = ret, PostId = ret.PostId
            };
            TempData["Liked"] = 0;
            if (ret.Interactions.Contains(curr)) TempData["Liked"] = 1;
            return View("~/Views/PostView.cshtml",ret);
        }



    }
}