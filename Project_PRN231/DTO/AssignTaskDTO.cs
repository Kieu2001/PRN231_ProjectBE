﻿using Project_PRN231.Models;

namespace Project_PRN231.DTO
{
    public class AssignTaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? LeaderId { get; set; }
        public int? WriterId { get; set; }
        public int? ReporterId { get; set; }
        public int? GenreId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Genre? Genre { get; set; }
        public virtual User? Leader { get; set; }
        public virtual User? Reporter { get; set; }
        public virtual User? Writer { get; set; }
        public virtual ICollection<ReportTaskDTO> ReportTasks { get; set; }
        public virtual ICollection<WritingTask> WritingTasks { get; set; }
    }
}
