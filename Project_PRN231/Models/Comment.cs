using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class Comment
    {
        public Comment()
        {
            ReplyComments = new HashSet<ReplyComment>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? NewsId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public int? LikeAmount { get; set; }
        public bool? IsActive { get; set; }

        public virtual News? News { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<ReplyComment> ReplyComments { get; set; }
    }
}
