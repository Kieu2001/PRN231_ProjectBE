using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class RejectGenre
    {
        public RejectGenre()
        {
            RejectTasks = new HashSet<RejectTask>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<RejectTask> RejectTasks { get; set; }
    }
}
