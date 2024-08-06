using InventarySystemAPI.Modules.Authentication.Domain.Interfaces;
using InventarySystemAPI.Modules.Authentication.Domain.Users;

namespace InventarySystemAPI.Modules.Authentication.Application
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;

        public AuthService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Login(string username, string password)
        {
            return await _repository.GetUserByLogin(username, password);
        }
        public async Task Register(string userId, string username, string password, string email)
        {
            var user = new User(); 
            user!.UserId = userId;
            user.Username = username;
            user.Password = password;
            user.Email = email;
            user.Active = true;
            await _repository.CreateUser(user);
        }
    }
}