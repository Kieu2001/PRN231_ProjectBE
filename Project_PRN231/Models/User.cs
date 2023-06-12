using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class User
    {
        public User()
        {
            AssignTaskLeaders = new HashSet<AssignTask>();
            AssignTaskReporters = new HashSet<AssignTask>();
            AssignTaskWriters = new HashSet<AssignTask>();
            Comments = new HashSet<Comment>();
            NewsSeens = new HashSet<NewsSeen>();
            RejectTasks = new HashSet<RejectTask>();
            ReplyComments = new HashSet<ReplyComment>();
            ReportTasks = new HashSet<ReportTask>();
            WritingTasks = new HashSet<WritingTask>();
        }

        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsBan { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<AssignTask> AssignTaskLeaders { get; set; }
        public virtual ICollection<AssignTask> AssignTaskReporters { get; set; }
        public virtual ICollection<AssignTask> AssignTaskWriters { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<NewsSeen> NewsSeens { get; set; }
        public virtual ICollection<RejectTask> RejectTasks { get; set; }
        public virtual ICollection<ReplyComment> ReplyComments { get; set; }
        public virtual ICollection<ReportTask> ReportTasks { get; set; }
        public virtual ICollection<WritingTask> WritingTasks { get; set; }
    }
}
