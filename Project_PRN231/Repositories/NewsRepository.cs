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


        public IEnumerable<Genre> GetAllGenres() => NewsManagement.Instance.GetAllGenres();

        public IEnumerable<News> GetNewsByGenreId(int id) => NewsManagement.Instance.GetNewsByGenreId(id);

        public News newsFirst() => NewsManagement.Instance.newsFirst();

        public IEnumerable<NewsDTO> GetNewsUserSeen(int userId,int cateId) => NewsManagement.Instance.GetNewsUserSeen(userId , cateId);

        public void AddNewsSeen(NewsSeen newsSave) => NewsManagement.Instance.AddNewsSeen(newsSave);

        public NewsSeen getNewsSeenById(int? userId, int? newsId) => NewsManagement.Instance.getNewsSeenById(userId, newsId);

        public NewsSeen getNewsSeen(int? userId, int? newsId) => NewsManagement.Instance.getNewsSeen(userId, newsId);

    }
}
