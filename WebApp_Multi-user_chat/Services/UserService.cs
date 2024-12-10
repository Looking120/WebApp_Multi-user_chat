using WebApp_Multi_user_chat.Entities;
using WebApp_Multi_user_chat.Interfaces;
using System.Linq;
using WebApp_Multi_user_chat.Data;
using Microsoft.EntityFrameworkCore;
using WebApp_Multi_user_chat.Dto;
using Mapster;

namespace WebApp_Multi_user_chat.Services
{
    public class UserService : IUserService
    {
        private readonly ChatDbContext _context;

        public UserService(ChatDbContext context)
        {
            _context = context;
        }

        public bool ValidateUser(User user)
        {
            // Vérifier si les informations utilisateur sont correctes
            var existingUser = _context.Users
                .FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            return existingUser != null;
        }

        public User? GetUserById(string username)
        {
            return _context.Users
                .AsNoTracking()
                .FirstOrDefault(u => u.UserName == username);
        }

        public async Task<bool> RegisterUser(UserRequest request)
        {
            if (await _context.Users.AnyAsync(u => u.UserName == request.UserName))
            {
                return false; // Utilisateur déjà existant
            }

            var user = request.Adapt<User>();
        
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserResponse> LoginAsync(UserRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName);

            ArgumentNullException.ThrowIfNull(user);

            if (!user.Password.Equals(request.Password))
            {
                throw new ArgumentException("Password or username is incorrect");
            }

            return user.Adapt<UserResponse>();
        }

        public async Task<List<User>> GetUsers()
        {
           return await _context.Users.ToListAsync();
        }
    }
}
