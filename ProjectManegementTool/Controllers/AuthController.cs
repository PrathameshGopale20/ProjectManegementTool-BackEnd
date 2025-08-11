using Microsoft.AspNetCore.Mvc;
using ProjectManegementTool.Dto_s;
using ProjectManegementTool.Interface;
using ProjectManegementTool.Services;

namespace ProjectManegementTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authRepo;
        private readonly TokenServices _tokenService;

        public AuthController(IAuth authRepo, TokenServices tokenService)
        {
            _authRepo = authRepo;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _authRepo.UserExists(dto.Email))
                return BadRequest("Email already exists");

            var user = await _authRepo.Register(dto);
            var token = _tokenService.CreateToken(user);
            return Ok(new AuthResponceDto { Success = true, Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _authRepo.Login(dto);
            if (user == null)
                return Unauthorized("Invalid username or password");

            var token = _tokenService.CreateToken(user);
            return Ok(new AuthResponceDto { Success = true, Token = token });
        }
    }
}





