using Project_PRN231.Models;

namespace Project_PRN231.Repositories.IRepository
{
    public interface INewsRepository
    {
        IEnumerable<News> GetNewsList();
        News getNewsById(int newsId);
        IEnumerable<News> GetListNewsByDate();
        int GetNewsByDate(int begin, int end);
        void AddNews(News news);
        void Update(News news);
        void Delete(News news);

        IEnumerable<Genre> GetAllGenres();
        IEnumerable<News> GetNewsByGenreId(int id);
        News newsFirst();

    }
}
