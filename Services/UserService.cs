using IAAPIUsers.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IAUsers.Services
{
    public class UserService : IUserService
    {
        public HttpClient _httpClient;
        public UserService(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _httpClient.GetFromJsonAsync<IEnumerable<User>>("v1/users");
            return users;
        }
        public async Task<User> GetUser(int id)
        {
            var user = await _httpClient.GetFromJsonAsync<User>($"v1/users/{id}");
            return user;
        }
        public async Task<User> CreateUser(User newUser)
        {
            var response = await _httpClient.PostAsJsonAsync<User>("v1/users", newUser);
            var content = await response.Content.ReadFromJsonAsync<User>();
            return content;
        }
        public async Task<User> UpdateUser(User updateUser)
        {
            var response = await _httpClient.PutAsJsonAsync<User>($"v1/users/{updateUser.Id}", updateUser);
            var content = await response.Content.ReadFromJsonAsync<User>();
            return content;
        }
        public async Task DeleteUser(int id)
        {
            await _httpClient.DeleteAsync($"v1/alunos/{id}");
        }
    }
}
