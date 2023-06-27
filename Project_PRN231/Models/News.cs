using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class News
    {
        public News()
        {
            Comments = new HashSet<Comment>();
            NewsSeens = new HashSet<NewsSeen>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? Entered { get; set; }
        public int? GenreId { get; set; }

        public virtual Genre? Genre { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<NewsSeen> NewsSeens { get; set; }
    }
}
