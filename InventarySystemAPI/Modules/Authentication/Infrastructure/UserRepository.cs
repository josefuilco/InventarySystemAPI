using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarySystemAPI.Context;
using InventarySystemAPI.Modules.Authentication.Domain.Interfaces;
using InventarySystemAPI.Modules.Authentication.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace InventarySystemAPI.Modules.Authentication.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly InventarySystemContext _context;

        public UserRepository(InventarySystemContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByLogin(string username, string password)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(user => user.Username == username && user.Password == password);
            if (currentUser == null) throw new Exception("User not found");
            return currentUser;
        }

        public async Task CreateUser(User user)
        {
            Console.WriteLine(user.Active);
            var result = await _context.Users.AddAsync(user);
            Console.WriteLine(result);
        }
    }
}