using Project_PRN231.DTO;
using Project_PRN231.Models;

namespace Project_PRN231.Repositories.IRepository
{
    public interface INewsRepository
    {
        IEnumerable<News> GetNewsList();
        News getNewsById(int newsId);
        IEnumerable<News> GetListNewsByDate();
        //int GetNewsByDate(int begin, int end);
        void AddNews(News news);
        void Update(News news);
        void Delete(News news);
        IEnumerable<News> GetNewsByDate2(int begin, int end);

        IEnumerable<Genre> GetAllGenres();
        IEnumerable<News> GetNewsByGenreId(int id);
        News newsFirst();
        IEnumerable<NewsDTO> GetNewsUserSeen(int userId, int cateId);
        void AddNewsSeen(NewsSeen newsSave);
        NewsSeen getNewsSeenById(int? userId, int? newsId);
        NewsSeen getNewsSeen(int? userId, int? newsId);
    }
}
