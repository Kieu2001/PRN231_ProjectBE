using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class NewsSeen
    {
        public int Id { get; set; }
        public DateTime? AddDate { get; set; }
        public int? UserId { get; set; }
        public int? NewsId { get; set; }
        public int? CateId { get; set; }

        public virtual CategoriesNewsSeen? Cate { get; set; }
        public virtual News? News { get; set; }
        public virtual User? User { get; set; }
    }
}
