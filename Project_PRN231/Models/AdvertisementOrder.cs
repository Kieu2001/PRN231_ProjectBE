using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class AdvertisementOrder
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? AdvertisementId { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public bool? IsPending { get; set; }
        public bool? IsApprove { get; set; }
        public int? Discount { get; set; }
    }
}
