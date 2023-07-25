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
        IEnumerable<NewsDTO> GetNewsUserSeen(string userId, int cateId);
        void AddNewsSeen(NewsSeen newsSave);
        NewsSeen getNewsSeenById(int? userId, int? newsId);
        NewsSeen getNewsSeen(int? userId, int? newsId);
        void AddComment(Comment con);
        IEnumerable<CommentDTO1> GetCommentByNewId(int id);
        void LikeComment(int newid);
        void UnLikeComment(int newid);
        int CountLike(int id);
        IEnumerable<News> GetNewsByName(string name);

    }
}
