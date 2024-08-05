using InventarySystemAPI.Modules.Authentication.Domain.Users;

namespace InventarySystemAPI.Modules.Authentication.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<User> Login(string username, string password);
        Task Register(string username, string password, string email);
    }
}