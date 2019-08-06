using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MVC_Task.Models;
using MVC_Task.ViewModel;

namespace MVC_Task.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult GetMovie(int id = 0)
        {
            if (id < 0 || id >= API.MoviesNo) return RedirectToAction("Error","Home");
            return View(API.GetMoviesData()[id]);
        }
        public ActionResult Index()
        {
            return View(new MovieList(API.GetMoviesData()));
        }


    }
}