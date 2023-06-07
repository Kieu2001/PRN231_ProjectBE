using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class RejectTask
    {
        public int Id { get; set; }
        public int? RejectId { get; set; }
        public string? Reason { get; set; }
        public int? TaskId { get; set; }
        public int? UserId { get; set; }
        public bool? IsReject { get; set; }

        public virtual RejectGenre? Reject { get; set; }
        public virtual AssignTask? Task { get; set; }
        public virtual User? User { get; set; }
    }
}
