using Project_PRN231.Models;

namespace Project_PRN231.DataAccess
{
    public class UserManagement
    {
        private static UserManagement instance = null;
        private static readonly object instanceLock = new object();
        private UserManagement() { }
        public static UserManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<User> GetUserList()
        {
            List<User> list = new List<User>();
            try
            {
                var db = new PRN231_SUContext();
                //list = db.AssignTasks.ToList();
                list = db.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public User GetUserById(int userId)
        {
            User? rp = null;
            try
            {
                var db = new PRN231_SUContext();
                rp = db.Users.SingleOrDefault(x => x.Id == userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rp;
        }

        public void AddNew(User user)
        {
            try
            {
                User rp = GetUserById(user.Id);
                if (rp == null)
                {
                    var db = new PRN231_SUContext();
                    db.Users.Add(user);
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

        public void Update(User user)
        {
            try
            {
                User rp = GetUserById(user.Id);
                if (rp != null)
                {
                    var db = new PRN231_SUContext();
                    db.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public void Delete(User user)
        {
            try
            {
                User rp = GetUserById(user.Id);
                if (rp != null)
                {
                    var db = new PRN231_SUContext();
                    db.Users.Remove(user);
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
