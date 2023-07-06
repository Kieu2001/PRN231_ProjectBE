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


        public IEnumerable<News> GetListNewsByDate()
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
        //public IEnumerable<News> newsFirst()
        //{
        //    try
        //    {
        //    var db = new PRN231_SUContext(); 
        //    var news = (from n in db.News
        //               orderby n.CreateDate descending
        //               select n).Take(1);
        //    return news;
        //    }catch(Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

          
        //}
        //public IEnumerable<News> newsFirst()
        //{
        //    try
        //    {
        //    var db = new PRN231_SUContext(); 
        //    var news = (from n in db.News
        //               orderby n.CreateDate descending
        //               select n).Take(1);
        //    return news;
        //    }catch(Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

          
        //}
        //public IEnumerable<News> newsFirst()
        //{
        //    try
        //    {
        //    var db = new PRN231_SUContext(); 
        //    var news = (from n in db.News
        //               orderby n.CreateDate descending
        //               select n).Take(1);
        //    return news;
        //    }catch(Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

          
        //}
        //public IEnumerable<News> newsFirst()
        //{
        //    try
        //    {
        //    var db = new PRN231_SUContext(); 
        //    var news = (from n in db.News
        //               orderby n.CreateDate descending
        //               select n).Take(1);
        //    return news;
        //    }catch(Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

          
        //}
        public News newsFirst()
        {
            try
            {
                News? news = null;
            var db = new PRN231_SUContext();
                news = db.News.OrderByDescending(x => x.CreateDate).FirstOrDefault();
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
        public IEnumerable<Genre> GetAllGenres()
        {
            List<Genre> genres = new List<Genre>();
            try
            {
                var db = new PRN231_SUContext();
                genres = db.Genres.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return genres;
        }

        public IEnumerable<News> GetNewsByGenreId(int id)
        {
            List<News> list = new List<News>();
            try
            {
                var db = new PRN231_SUContext();
                list = db.News.Where(x => x.GenreId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public int GetNewsByDate(int begin, int end)
        {
            DateTime startDate = DateTime.Now.AddDays(-begin);
            DateTime endDate = DateTime.Now.AddDays(-end);


            using (var db = new PRN231_SUContext())
            {
                return db.News.Count(u => u.CreateDate >= endDate && u.CreateDate <= startDate);
            }
        }
        public void AddNewsSave(NewsSeen newsSave)
        {
            try
            {
                var db = new PRN231_SUContext();
                db.NewsSeens.Add(newsSave);
                db.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NewsDTO> GetNewsUserSeen(int userId)
        {
            List<NewsDTO> list = new List<NewsDTO>();
            try
            {
                using ( var db = new PRN231_SUContext())
                {
                    list = (from n in db.News
                            join ns in db.NewsSeens on n.Id equals ns.NewsId
                            where ns.UserId == userId
                            select new NewsDTO
                            {
                                Id= n.Id,
                                Content= n.Content,
                                CreateBy= n.CreateBy,
                                CreateDate= n.CreateDate,
                                Description= n.Description,
                                Entered= n.Entered,
                                GenreId= n.GenreId,
                                Image= n.Image,
                                Title= n.Title, 
                                UpdateBy= n.UpdateBy,   
                                UpdateDate= n.UpdateDate,
                            }).ToList();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }
    }
}
