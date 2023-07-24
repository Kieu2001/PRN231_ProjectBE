using Microsoft.EntityFrameworkCore;
using Project_PRN231.DTO;
using Project_PRN231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_PRN231.DataAccess
{
    public class NewsManagement
    {
        private static NewsManagement instance = null;
        private static readonly object instanceLock = new object();
        private NewsManagement() { }

        public static NewsManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
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
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public News getNewsById(int newsId)
        {
            News? news = null;
            try
            {
                var db = new PRN231_SUContext();
                news = db.News.SingleOrDefault(x => x.Id == newsId);
            } catch (Exception ex)
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
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public void AddNews(News news)
        {
            try {
                News news1 = getNewsById(news.Id);
                if(news1 == null) {
                    var db = new PRN231_SUContext();
                    db.News.Add(news);
                    db.SaveChanges();
                }
            } catch (Exception ex)
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

        public NewsSeen getNewsSeenById(int? userId, int? newsId)
        {
            NewsSeen? news = null;
            try
            {
                var db = new PRN231_SUContext();
                news = db.NewsSeens.FirstOrDefault(x => x.UserId == userId && x.NewsId == newsId);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return news;
        }
        public NewsSeen getNewsSeen(int? userId, int? newsId)
        {
            NewsSeen? news = null;
            try
            {
                var db = new PRN231_SUContext();
                news = db.NewsSeens.FirstOrDefault(x => x.UserId == userId && x.NewsId == newsId && x.CateId != 1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return news;
        }

        public void AddNewsSeen(NewsSeen newsSave)
        {
            try
            {
                var db = new PRN231_SUContext();
                db.NewsSeens.Add(newsSave);
                db.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NewsDTO> GetNewsUserSeen(int userId, int cateId)
        {
            List<NewsDTO> list = new List<NewsDTO>();
            try
            {
                using (var db = new PRN231_SUContext())
                {
                    list = (from n in db.News
                            join ns in db.NewsSeens on n.Id equals ns.NewsId
                            where ns.UserId == userId && ns.CateId == cateId
                            select new NewsDTO
                            {
                                Id = n.Id,
                                Content = n.Content,
                                CreateBy = n.CreateBy,
                                CreateDate = n.CreateDate,
                                Description = n.Description,
                                Entered = n.Entered,
                                GenreId = n.GenreId,
                                
                                Image = n.Image,
                                Title = n.Title,
                                UpdateBy = n.UpdateBy,
                                UpdateDate = n.UpdateDate,
                            }).ToList();
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }
      
        public void AddComment(Comment con)
        {
            try
            {
                var db = new PRN231_SUContext();
                db.Comments.Add(con);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<CommentDTO1> GetCommentByNewId(int id)
        {
            List<CommentDTO1> list = new List<CommentDTO1>();
            try
            {
                var db = new PRN231_SUContext();
                var l = db.Comments.Include(i => i.User).Where(i => i.NewsId == id).ToList();
                var user = db.Users.ToList();
                foreach (var item in l)
                {
                    CommentDTO1 cd = new CommentDTO1
                    {
                        Id = item.Id,
                        NewsId = item.NewsId,
                        UserName = item.User.FullName,
                        Content = item.Content,
                        CreateDate = item.CreateDate,
                        IsActive = item.IsActive,
                        LikeAmount = item.LikeAmount
                    };
                    list.Add(cd);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public void DeleteComment(int id)
        {
            Comment comment = null;
            try
            {
                var db = new PRN231_SUContext();
                comment = db.Comments.Where(x => x.Equals(id)).FirstOrDefault();
                db.Comments.Remove(comment);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LikeComment(int newid)
        {
            var db = new PRN231_SUContext();
            var newc = db.Comments.Where(x => x.Id == newid).FirstOrDefault();

            newc.LikeAmount = newc.LikeAmount + 1;
            db.Entry<Comment>(newc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void UnLikeComment(int newid)
        {
            var db = new PRN231_SUContext();
            var newc = db.Comments.Where(x => x.Id == newid).FirstOrDefault();

            newc.LikeAmount = newc.LikeAmount - 1;
            db.Entry<Comment>(newc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public int CountLike(int id)
        {
            var db = new PRN231_SUContext();
            int n = (int)db.Comments.Where(x => x.Id == id).Select(x => x.LikeAmount).FirstOrDefault();
            return n;
        }

        public IEnumerable<News> GetNewsByName(string name)
        {
            List<News> news = new List<News>();

            var db = new PRN231_SUContext();
            news = db.News.Where(x => x.Title.ToLower().Contains(name)).ToList();
            return news;
        }
      
        public IEnumerable<News> GetNewsByDate2(int begin, int end)
        {
            List<News> listNews = new List<News>();
            try
            {
                using (var db = new PRN231_SUContext()) // Tạo mới đối tượng PRN231_SUContext và sử dụng nó
                {
                    // Lấy ngày hiện tại
                    DateTime currentDate = DateTime.Now;

                    // Tính ngày bắt đầu và kết thúc
                    DateTime startDate = currentDate.AddDays(-begin); // Lấy ngày bắt đầu trong ngày (00:00:00)
                    DateTime endDate = currentDate.AddDays(-end); // Lấy ngày kết thúc trong ngày (00:00:00)

                    // Truy vấn danh sách các tin tức có CreateDate nằm trong khoảng startDate và endDate
                    listNews = db.News.Where(x => x.CreateDate >= endDate && x.CreateDate <= startDate)
                                        .ToList();
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý ngoại lệ ở đây (tùy vào yêu cầu ứng dụng của bạn)
                // Ví dụ: Console.WriteLine(ex.Message);
                // Hoặc: Logger.LogError(ex, "Lỗi trong quá trình lấy tin tức theo ngày.");

                // Trả về danh sách tin tức trống trong trường hợp xảy ra lỗi
                return new List<News>();
            }

            return listNews;

        }     
    }
}
