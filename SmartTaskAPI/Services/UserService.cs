using Microsoft.EntityFrameworkCore;
using SmartTaskAPI.Data;
using SmartTaskAPI.DTOs;

namespace SmartTaskAPI.Services
{
    public class UserService : IUserService
    {
        private readonly SmartTaskDbContext _context;

        public UserService(SmartTaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            return await _context.Users
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email
                })
                .ToListAsync();
        }

        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return null;

            return new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email
            };
        }
    }
}