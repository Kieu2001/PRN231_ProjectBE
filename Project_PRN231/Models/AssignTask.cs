using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class AssignTask
    {
        public AssignTask()
        {
            Documents = new HashSet<Document>();
            RejectTasks = new HashSet<RejectTask>();
            ReportTasks = new HashSet<ReportTask>();
            WritingTasks = new HashSet<WritingTask>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? LeaderId { get; set; }
        public int? WriterId { get; set; }
        public int? ReporterId { get; set; }
        public int? GenreId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsReportAccept { get; set; }
        public bool? IsWriterAccept { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Genre? Genre { get; set; }
        public virtual User? Leader { get; set; }
        public virtual User? Reporter { get; set; }
        public virtual User? Writer { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<RejectTask> RejectTasks { get; set; }
        public virtual ICollection<ReportTask> ReportTasks { get; set; }
        public virtual ICollection<WritingTask> WritingTasks { get; set; }
    }
}
