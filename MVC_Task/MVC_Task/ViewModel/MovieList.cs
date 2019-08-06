using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Task.Models;

namespace MVC_Task.ViewModel
{
    public class MovieList
    {
        public List<Movie> data { get; }
        public MovieList(List<Movie> data)
        {
            this.data = new List<Movie>(data);
        }
    }
}