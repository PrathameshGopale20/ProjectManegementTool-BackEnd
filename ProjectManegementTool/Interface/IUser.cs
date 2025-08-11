using ProjectManegementTool.Dto_s;
using ProjectManegementTool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManegementTool.Interface
{
    public interface IUserRepository
    {
        Task<Users> CreateUserAsync(CreateUserDto dto);
        Task<List<Users>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(int id);
    }
}





