using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Task.Models;

namespace MVC_Task.ViewModel
{
    public class CustomerList
    {
        public List<Customers> data { get; }
        public CustomerList(List<Customers> data)
        {
            this.data = new List<Customers>(data);
        }
    }
}