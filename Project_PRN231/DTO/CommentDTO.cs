namespace Project_PRN231.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int? NewsId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public int? LikeAmount { get; set; }
        public bool? IsActive { get; set; }
    }
}
