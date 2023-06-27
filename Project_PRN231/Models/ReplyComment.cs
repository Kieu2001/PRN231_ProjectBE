using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class ReplyComment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public int? LikeAmount { get; set; }
        public bool? IsActive { get; set; }

        public virtual Comment Comment { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
