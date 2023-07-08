using Project_PRN231.DTO;
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

        public IEnumerable<UserDTO> GetUserList()
        {
            List<UserDTO> userList = new List<UserDTO>();
            try
            {
                using (var db = new PRN231_SUContext())
                {
                    userList = (from u in db.Users
                                join r in db.Roles on u.RoleId equals r.Id
                                select new UserDTO
                                {
                                    Id = u.Id,
                                    FullName = u.FullName,
                                    Email = u.Email,
                                    Password = u.Password,
                                    Phone = u.Phone,
                                    Address = u.Address,
                                    RoleName = r.RoleName,
                                    CreateDate = u.CreateDate,
                                }).ToList();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userList;
        }

        public int GetUserData(int numberOfDays)
        {
            DateTime startDate = DateTime.Now.AddDays(-numberOfDays);

            using (var db = new PRN231_SUContext())
            {
                return db.Users.Count(u => u.CreateDate >= startDate && u.CreateDate <= DateTime.Now);
            }
        }



        public IEnumerable<UserDTO> GetUserListBan(Boolean Ban)
        {
            List<UserDTO> userList = new List<UserDTO>();
            try
            {
                using (var db = new PRN231_SUContext())
                {
                    userList = (from u in db.Users
                                join r in db.Roles on u.RoleId equals r.Id
                                where u.IsBan == Ban
                                select new UserDTO
                                {
                                    Id = u.Id,
                                    FullName = u.FullName,
                                    Email = u.Email,
                                    Password = u.Password,
                                    Phone = u.Phone,
                                    Address = u.Address,
                                    RoleName = r.RoleName,
                                    CreateDate = u.CreateDate,
                                }).ToList();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userList;
        }


        public IEnumerable<UserDTO> GetUserRole(int Id)
        {
            DateTime startDate = DateTime.Now.AddDays(-30);

            List<UserDTO> userList = new List<UserDTO>();
            try
            {
                using (var db = new PRN231_SUContext())
                {
                    userList = (from u in db.Users
                                join r in db.Roles on u.RoleId equals r.Id
                                where u.RoleId == Id && u.CreateDate >= startDate
                                select new UserDTO
                                {
                                    Id = u.Id,
                                    FullName = u.FullName,
                                    Email = u.Email,
                                    Password = u.Password,
                                    Phone = u.Phone,
                                    Address = u.Address,
                                    RoleName = r.RoleName,
                                    RoleId = u.RoleId,
                                    CreateDate = u.CreateDate,
                                }).ToList();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userList;
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
