using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class CategoriesNewsSeen
    {
        public CategoriesNewsSeen()
        {
            NewsSeens = new HashSet<NewsSeen>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<NewsSeen> NewsSeens { get; set; }
    }
}
