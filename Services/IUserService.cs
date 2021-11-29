using IAAPIUsers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IAUsers.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> UpdateUser(User updateUser);
        Task<User> CreateUser(User newUser);
        Task DeleteUser(int id);
    }
}
