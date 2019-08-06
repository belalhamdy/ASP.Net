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
            var interaction = context.Interactions.Find(id, User.Identity.GetUserId());
            var c = ret.Interactions.ToList();
            bool like = interaction != null;
            return View("~/Views/PostView.cshtml",new postViewModel{CurrentPost = ret , Liked = like});
        }

        [HttpPost]
        public ActionResult AddComment(postViewModel comment)
        {
            if (comment.text != null)
                Logic.AddComment(User.Identity.GetUserId(), comment.CurrentPost.PostId, comment.text, null);
            return RedirectToAction("ViewPost",new {id = comment.CurrentPost.PostId });
        }
        public ActionResult AddInteraction(string id)
        {
            Logic.AddInteraction(User.Identity.GetUserId(), id, 1);

            return RedirectToAction("ViewPost", new { id = id });
        }
        public ActionResult RemoveInteraction(string id)
        {

                Logic.RemoveInteraction(User.Identity.GetUserId(), id ,1);
                return RedirectToAction("ViewPost", new { id = id });
        }



    }
}