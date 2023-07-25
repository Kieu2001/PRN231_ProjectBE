using Project_PRN231.DataAccess;
using Project_PRN231.DTO;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_PRN231.Repositories
{
    public class NewsRepository : INewsRepository
    {
        public void AddNews(News news) => NewsManagement.Instance.AddNews(news);

        public void Delete(News news) => NewsManagement.Instance.Delete(news);

        public IEnumerable<News> GetListNewsByDate() => NewsManagement.Instance.GetListNewsByDate();

        public News getNewsById(int newsId) => NewsManagement.Instance.getNewsById(newsId);

        public IEnumerable<News> GetNewsList() => NewsManagement.Instance.GetNewsList();

        public void Update(News news) => NewsManagement.Instance.Update(news);

        public IEnumerable<News> GetNewsByDate2(int begin, int end) => NewsManagement.Instance.GetNewsByDate2(begin, end);

        public IEnumerable<Genre> GetAllGenres() => NewsManagement.Instance.GetAllGenres();

        public IEnumerable<News> GetNewsByGenreId(int id) => NewsManagement.Instance.GetNewsByGenreId(id);

        public News newsFirst() => NewsManagement.Instance.newsFirst();

        //public IEnumerable<NewsDTO> GetNewsUserSeen(string userId,int cateId) => NewsManagement.Instance.GetNewsUserSeen(userId , cateId);

        public void AddNewsSeen(NewsSeen newsSave) => NewsManagement.Instance.AddNewsSeen(newsSave);

        public NewsSeen getNewsSeenById(int? userId, int? newsId) => NewsManagement.Instance.getNewsSeenById(userId, newsId);

        public NewsSeen getNewsSeen(int? userId, int? newsId) => NewsManagement.Instance.getNewsSeen(userId, newsId);

        public void AddComment(Comment con) => NewsManagement.Instance.AddComment(con);

        public IEnumerable<CommentDTO1> GetCommentByNewId(int id) => NewsManagement.Instance.GetCommentByNewId(id);

        public void LikeComment(int newid) => NewsManagement.Instance.LikeComment(newid);

        public void UnLikeComment(int newid) => NewsManagement.Instance.UnLikeComment(newid);

        public int CountLike(int id) => NewsManagement.Instance.CountLike(id);

        public IEnumerable<News> GetNewsByName(string name) => NewsManagement.Instance.GetNewsByName(name);

        public IEnumerable<NewsDTO> GetNewsUserSeen(string userId, int cateId) => NewsManagement.Instance.GetNewsUserSeen(userId, cateId);
    }
}
