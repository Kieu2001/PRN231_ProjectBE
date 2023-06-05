using Project_PRN231.DataAccess;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        public void DeleteGenre(int genreId) => GenreManagement.Instance.Delete(genreId);

        public IEnumerable<Genre> GetAllGenre() => GenreManagement.Instance.GetGenreList();

        public Genre GetGenreById(int Id) => GenreManagement.Instance.GetGenreById(Id);

        public void InsertGenre(Genre genre) => GenreManagement.Instance.AddNew(genre);

        public void UpdateGenre(Genre genre) => GenreManagement.Instance.Update(genre); 
    }
}
