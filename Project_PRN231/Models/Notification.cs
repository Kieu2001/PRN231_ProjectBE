using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public int? TaskId { get; set; }
        public int? UserId { get; set; }
        public int? CateId { get; set; }
        public bool? IsRead { get; set; }

        public virtual NotificationCate? Cate { get; set; }
        public virtual User? User { get; set; }
    }
}
