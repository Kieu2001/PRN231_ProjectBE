using Project_PRN231.Models;

namespace Project_PRN231.Repositories.IRepository
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAllGenre();
        Genre GetGenreById(int Id);
        void InsertGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(Genre genre);
    }
}
