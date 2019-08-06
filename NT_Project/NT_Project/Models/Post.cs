using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NT_Project.Models
{
    public class Post
    {
        [Key]
        public string PostId { get; set; }


        public string Text { get; set; }
        public string ContentPath { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [InverseProperty("Post")]
        public virtual ICollection<Interaction> Interactions { get; set; }

        [InverseProperty("Post")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}