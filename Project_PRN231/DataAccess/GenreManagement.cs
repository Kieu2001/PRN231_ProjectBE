using Project_PRN231.Models;

namespace Project_PRN231.DataAccess
{
    public class GenreManagement
    {
        private static GenreManagement instance = null;
        private static readonly object instanceLock = new object();
        private GenreManagement() { }
        public static GenreManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new GenreManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Genre> GetGenreList()
        {
            List<Genre> list = new List<Genre>();
            try
            {
                var db = new PRN231_SUContext();
                //list = db.AssignTasks.ToList();
                list = db.Genres.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public Genre GetGenreById(int genreID)
        {
            Genre? rp = null;
            try
            {
                var db = new PRN231_SUContext();
                rp = db.Genres.SingleOrDefault(x => x.Id == genreID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rp;
        }

        public void AddNew(Genre genre)
        {
            try
            {
                Genre rp = GetGenreById(genre.Id);
                if (rp == null)
                {
                    var db = new PRN231_SUContext();
                    db.Genres.Add(genre);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This genre is already done");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Genre genre)
        {
            try
            {
                Genre rp = GetGenreById(genre.Id);
                if (rp != null)
                {
                    var db = new PRN231_SUContext();
                    db.Entry<Genre>(genre).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This genre does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Genre genre)
        {
            try
            {
                Genre rp = GetGenreById(genre.Id);
                if (rp != null)
                {
                    var db = new PRN231_SUContext();
                    db.Genres.Remove(genre);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This genre does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
