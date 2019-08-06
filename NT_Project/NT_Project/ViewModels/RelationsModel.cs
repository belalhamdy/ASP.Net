using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using NT_Project.Models;

namespace NT_Project.ViewModels
{
    public class RelationsModel
    {
        public ApplicationUser User { get; set; }
        public int Type { get; set; }

    }
}