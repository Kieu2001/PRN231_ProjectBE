using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class WritingTask
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public string? Comment { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsChecked { get; set; }
        public int? UserId { get; set; }
        public int? TaskId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsLated { get; set; }

        public virtual AssignTask? Task { get; set; }
        public virtual User? User { get; set; }
    }
}
