using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class NotificationCate
    {
        public NotificationCate()
        {
            Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
