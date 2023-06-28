using Project_PRN231.DTO;
using Project_PRN231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_PRN231.DataAccess
{
    public class NewsManagement
    {
        private static NewsManagement instance = null;
        private static readonly object instanceLock = new object();
        private  NewsManagement() { }

        public static NewsManagement Instance
        {
            get
            {
                lock(instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new NewsManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<News> GetNewsList()
        {
            List<News> list = new List<News>();
            try
            {
                var db = new PRN231_SUContext();
                list = db.News.ToList();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public News getNewsById(int newsId)
        {
            News? news= null;
            try
            {
                var db = new PRN231_SUContext();
                news = db.News.SingleOrDefault(x => x.Id == newsId);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return news;
        }


        public IEnumerable<News> GetNewsByDate()
        {
            List<News> listNewsByDate = new List<News>();
            //try
            //{
            //    var db = new PRN231_SUContext();
            //    listNewsByDate = db.News.OrderBy(x=>x.CreateDate).ToList();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            return listNewsByDate;
        }
        public IEnumerable<News> newsFirst()
        {
            try
            {
            var db = new PRN231_SUContext(); 
            var news = (from n in db.News
                       orderby n.CreateDate descending
                       select n).Take(1);
            return news;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

          
        }
        public IEnumerable<News> newsFirst()
        {
            try
            {
            var db = new PRN231_SUContext(); 
            var news = (from n in db.News
                       orderby n.CreateDate descending
                       select n).Take(1);
            return news;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

          
        }
        public IEnumerable<News> newsFirst()
        {
            try
            {
            var db = new PRN231_SUContext(); 
            var news = (from n in db.News
                       orderby n.CreateDate descending
                       select n).Take(1);
            return news;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

          
        }
        public IEnumerable<News> newsFirst()
        {
            try
            {
            var db = new PRN231_SUContext(); 
            var news = (from n in db.News
                       orderby n.CreateDate descending
                       select n).Take(1);
            return news;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

          
        }
        public IEnumerable<News> newsFirst()
        {
            try
            {
            var db = new PRN231_SUContext(); 
            var news = (from n in db.News
                       orderby n.CreateDate descending
                       select n).Take(1);
            return news;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

          
        }

        public void AddNews(News news)
        {
            try{ 
                News news1 = getNewsById(news.Id);
                if(news1 != null)
                {
                    var db = new PRN231_SUContext();
                    db.News.Add(news1);
                    db.SaveChanges();
                }
            }catch(Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }

        public void Update(News news)
        {
            try
            {
                News news1 = getNewsById(news.Id);
                if (news1 != null)
                {
                    var db = new PRN231_SUContext();
                    db.Entry<News>(news1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(News news)
        {
            try
            {
                News news1 = getNewsById(news.Id);
                if (news1 != null)
                {
                    var db = new PRN231_SUContext();
                    db.News.Remove(news1);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
