using Microsoft.EntityFrameworkCore;
using ProjectManegementTool.Data;
using ProjectManegementTool.Dto_s;
using ProjectManegementTool.Interface;
using ProjectManegementTool.Models;
using Microsoft.AspNetCore.Identity;

namespace ProjectManegementTool.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<Users> _hasher;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            _hasher = new PasswordHasher<Users>();
        }

        public async Task<Users> CreateUserAsync(CreateUserDto dto)
        {
            var emailExists = await _context.Users.AnyAsync(u => u.Email.ToLower() == dto.Email.ToLower());
            if (emailExists)
                throw new Exception("User with this email already exists.");

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == dto.RolesId);
            if (role == null)
                throw new KeyNotFoundException("Role does not exist.");

            var user = new Users
            {
                Name = dto.Name,
                Email = dto.Email,
                DOB = dto.DOB,
                Designation = dto.Designation,
                RolesId = dto.RolesId,
                Profile_Img = dto.Profile_Img ?? "default.png",
                Password = _hasher.HashPassword(null!, dto.Password)
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}





