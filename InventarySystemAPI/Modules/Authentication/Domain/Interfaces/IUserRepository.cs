using InventarySystemAPI.Modules.Authentication.Domain.Users;

namespace InventarySystemAPI.Modules.Authentication.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByLogin(string username, string password);
        Task CreateUser(User user);
    }
}