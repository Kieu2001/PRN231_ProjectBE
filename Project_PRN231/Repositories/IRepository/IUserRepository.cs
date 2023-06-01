using Project_PRN231.Models;

namespace Project_PRN231.Repositories.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int Id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
