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

        public News GetNews(int id)
        {
            News? news= null;
            try
            {
                var db = new PRN231_SUContext();
                news = db.News.SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return news;
        }
        public IEnumerable<News> GetNewsByDate()
        {
            List<News> listNewsByDate = new List<News>();
            try
            {
                var db = new PRN231_SUContext();
                listNewsByDate = db.News.OrderBy(x=>x.CreateDate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listNewsByDate;
        }
        public void AddNews(News news)
        {
            try{ 
                News news1 ;
            }catch(Exception ex) { throw new Exception(ex.Message);}
        }
    }
}
