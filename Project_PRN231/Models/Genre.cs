using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class Genre
    {
        public Genre()
        {
            AssignTasks = new HashSet<AssignTask>();
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public string GenreName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<AssignTask> AssignTasks { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
