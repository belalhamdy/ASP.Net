using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NT_Project.Models
{
    public class Relationship
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("First")]
        public string FirstId { get; set; }
        public virtual ApplicationUser First { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Second")]
        public string SecondId { get; set; }
        public virtual ApplicationUser Second { get; set; }

        public int type { get; set; } 

        /*
         0 -> friends
         1 -> first request to second 
         -1 -> second request to first
         2 -> first blocked second
         -2 -> second blocked first
         */
    




    }
}