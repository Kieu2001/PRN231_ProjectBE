using System;
using System.Collections.Generic;

namespace Project_PRN231.Models
{
    public partial class Advertisement
    {
        public Advertisement()
        {
            AdvertisementOrders = new HashSet<AdvertisementOrder>();
        }

        public int Id { get; set; }
        public decimal? Price { get; set; }
        public int? TotalDate { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<AdvertisementOrder> AdvertisementOrders { get; set; }
    }
}
