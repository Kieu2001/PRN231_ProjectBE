using Project_PRN231.Models;

namespace Project_PRN231.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<AssignTask> AssignTaskLeaders { get; set; }
        public virtual ICollection<AssignTask> AssignTaskReporters { get; set; }
        public virtual ICollection<AssignTask> AssignTaskWriters { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<NewsSeen> NewsSeens { get; set; }
        public virtual ICollection<ReplyComment> ReplyComments { get; set; }
        public virtual ICollection<ReportTask> ReportTasks { get; set; }
        public virtual ICollection<WritingTask> WritingTasks { get; set; }
    }
}
