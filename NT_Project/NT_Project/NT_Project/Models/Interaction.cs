using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NT_Project.Models
{
    public class Interaction
    {
        public int ActionType { get; set; } //1 -> Like , 2 -> Dislike
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Post")]
        public string PostId { get; set; }
        public virtual Post Post { get; set; }


        [Key]
        [Column(Order = 2)]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }




    }
}