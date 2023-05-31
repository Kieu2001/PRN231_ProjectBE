using Project_PRN231.Models;

namespace Project_PRN231.DTO
{
    public class GenresDTO
    {
        public int Id { get; set; }
        public string GenreName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<AssignTask> AssignTasks { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
