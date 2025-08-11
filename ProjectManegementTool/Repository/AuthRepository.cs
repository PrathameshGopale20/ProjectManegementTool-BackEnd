using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManegementTool.Data;
using ProjectManegementTool.Dto_s;
using ProjectManegementTool.Interface;
using ProjectManegementTool.Models;

namespace ProjectManegementTool.Repository
{
    public class AuthRepository : IAuth
    {
        private readonly AppDbContext _dbContext;
        private readonly PasswordHasher<Users> _hasher;

        public AuthRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _hasher = new PasswordHasher<Users>();
        }

        public async Task<bool> UserExists(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<Users> Register(RegisterDto dto)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == dto.RolesId);
            if (role == null)
            {
                throw new Exception("Role does not exist");
            }

            var user = new Users
            {
                Name = dto.Name,
                Email = dto.Email,
                Designation = dto.Designation,
                RolesId = role.Id,
                Profile_Img = "default.png" 
            };

            user.Password = _hasher.HashPassword(user, dto.Password);

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<Users?> Login(LoginDto dto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (user == null)
                return null;

            var result = _hasher.VerifyHashedPassword(user, user.Password!, dto.Password);
            return result == PasswordVerificationResult.Success ? user : null;
        }

    }
}




