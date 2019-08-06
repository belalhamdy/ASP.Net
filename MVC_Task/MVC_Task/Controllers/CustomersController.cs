using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Task.Models;
using MVC_Task.ViewModel;

namespace MVC_Task.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View(new CustomerList(API.GetCustomersData()));
        }
        public ActionResult GetCustomer(int id = 0)
        {
            if (id < 0 || id >= API.CustomerNo) return RedirectToAction("Error", "Home");
            return View(API.GetCustomersData()[id]);
        }
    }
}