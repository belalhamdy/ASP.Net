using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NT_Project.Models;

namespace NT_Project.ViewModels
{
    public class FriendsPostModel
    {
        public ApplicationUser user { get; set; }
        public List<Post> Posts { get; set; }
    }
}