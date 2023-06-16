using Project_PRN231.DataAccess;
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

        public IEnumerable<News> GetNewsByDate() => NewsManagement.Instance.GetNewsByDate();

        public News getNewsById(int newsId) => NewsManagement.Instance.getNewsById(newsId);

        public IEnumerable<News> GetNewsList() => NewsManagement.Instance.GetNewsList();

        public void Update(News news) => NewsManagement.Instance.Update(news);

        public IEnumerable<Genre> GetAllGenres() => NewsManagement.Instance.GetAllGenres();

        public IEnumerable<News> GetNewsByGenreId(int id) => NewsManagement.Instance.GetNewsByGenreId(id);
        
    }
}
