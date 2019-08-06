using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NT_Project.Models;

namespace NT_Project.Controllers
{
    public class InteractionsController : Controller
    {

        //public ActionResult Index()
        //{
        //    return View();
        //}
        protected Logic Logic = new Logic();

        public ActionResult GetInteractions(string id)
        {
            return View(Logic.GetInteractions(id));
        }
    }
}