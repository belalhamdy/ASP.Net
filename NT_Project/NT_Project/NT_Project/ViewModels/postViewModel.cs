using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NT_Project.Models;

namespace NT_Project.ViewModels
{
    public class postViewModel
    {
        public string text { get; set; }
        public string content { get; set; }
        public List<Post> posts { get; set; }
        public Post CurrentPost { get; set; }
        public bool Liked { get; set; }
    }
}