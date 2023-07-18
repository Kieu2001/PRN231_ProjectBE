using Project_PRN231.DataAccess;
using Project_PRN231.DTO;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void DeleteUser(User user) => UserManagement.Instance.Delete(user);
        public IEnumerable<UserDTO> GetAllUser() => UserManagement.Instance.GetUserList();

        //public IEnumerable<User> GetAllUser() => (IEnumerable<User>)UserManagement.Instance.GetUserList();

        public User GetUserById(int Id) => UserManagement.Instance.GetUserById(Id);

        public void InsertUser(User user) => UserManagement.Instance.AddNew(user);

        public void UpdateUser(User user) => UserManagement.Instance.Update(user);

        IEnumerable<User> IUserRepository.GetAllUser() => UserManagement.Instance.GetUser();
    }
}
