using ProjectManegementTool.Dto_s;
using ProjectManegementTool.Models;

namespace ProjectManegementTool.Interface
{
    public interface IAuth
    {
        Task<bool> UserExists(string email);
        Task<Users> Register(RegisterDto dto);
        Task<Users> Login(LoginDto dto);
    }
}





