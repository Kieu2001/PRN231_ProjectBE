using Project_PRN231.DTO;
using Project_PRN231.Models;

namespace Project_PRN231.DataAccess
{
    public class CommentManagement
    {

        private static CommentManagement instance = null;
        private static readonly object instanceLock = new object();
        private CommentManagement() { }
        public static CommentManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CommentManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<CommentDTO> GetCommentBrowseList()
        {
            List<CommentDTO> list = new List<CommentDTO>();
            try
            {
                var db = new PRN231_SUContext();

                list = (from c in db.Comments
                        join u in db.Users on c.UserId equals u.Id
                        join n in db.News on c.NewsId equals n.Id
                        where c.IsActive == null
                        select new CommentDTO
                        {
                            Id = c.Id,
                            Title = n.Title,
                            Content = c.Content,
                            CreateDate = (DateTime)n.CreateDate,
                            FullName = u.FullName
                        }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public Comment GetCommentById(int commentId)
        {
            Comment? rp = null;
            try
            {
                var db = new PRN231_SUContext();
                rp = db.Comments.SingleOrDefault(x => x.Id == commentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rp;
        }

        public void AddNew(Comment comment)
        {
            try
            {
                Comment rp = GetCommentById(comment.Id);
                if (rp == null)
                {
                    var db = new PRN231_SUContext();
                    db.Comments.Add(comment);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This user is already done");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateTrue(int id)
        {
            try
            {
                Comment comment = GetCommentById(id);
                if (comment != null)
                {
                    comment.IsActive = true; // Chuyển trạng thái isActive sang true

                    var db = new PRN231_SUContext();
                    db.Entry<Comment>(comment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This comment does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateFalse(int id)
        {
            try
            {
                Comment comment = GetCommentById(id);
                if (comment != null)
                {
                    comment.IsActive = false; // Chuyển trạng thái isActive sang true

                    var db = new PRN231_SUContext();
                    db.Entry<Comment>(comment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This comment does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Delete(int id)
        {
            try
            {
                Comment rp = GetCommentById(id);
                if (rp != null)
                {
                    var db = new PRN231_SUContext();
                    db.Comments.Remove(rp);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This user does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
