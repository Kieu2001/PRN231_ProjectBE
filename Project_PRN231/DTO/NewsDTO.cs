using Project_PRN231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_PRN231.DTO
{
    public class NewsDTO
    {
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

        //public virtual Genre? Genre { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
        //public virtual ICollection<NewsSeen> NewsSeens { get; set; }
    }
    public class NewsSeenDTO
    {
        public int Id { get; set; }
        public DateTime? AddDate { get; set; }
        public int? UserId { get; set; }
        public int? NewsId { get; set; }
        public int? CateId { get; set; }

        //public virtual Genre? Genre { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
        //public virtual ICollection<NewsSeen> NewsSeens { get; set; }
    }
}
