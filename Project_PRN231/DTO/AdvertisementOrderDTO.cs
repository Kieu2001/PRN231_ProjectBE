namespace Project_PRN231.DTO
{
    public class AdvertisementOrderDTO
    {
        public   int Id { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public long AdType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }


    }
}
