using Project_PRN231.DTO;
using Project_PRN231.Models;

namespace Project_PRN231.Repositories.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<DTO.UserDTO> GetAllUser();
        User GetUserById(int Id);
        User GetUserByEmail(string email);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        IEnumerable<DTO.UserDTO> GetUserListBan(Boolean Ban);
        int GetUserData(int numberOfDays);
        IEnumerable<UserDTO> GetUserRole(int RoleId);
    }
}
