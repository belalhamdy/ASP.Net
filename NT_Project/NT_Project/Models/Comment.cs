using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NT_Project.Models
{
    public class Comment
    {

        public string CommentId { get; set; }
        public string Text { get; set; }
        public string ContentPath { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Post")]
        public string PostId { get; set; }
        public virtual Post Post { get; set; }

    }
}