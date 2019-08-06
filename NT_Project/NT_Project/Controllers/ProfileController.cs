using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace NT_Project.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        Logic Logic = new Logic();
        public ActionResult Index(string id)
        {
            if (id.IsNullOrWhiteSpace()) id = User.Identity.GetUserId();
            return View("~/Views/Profile.cshtml",Logic.GetUser(id));
        }
    }
}