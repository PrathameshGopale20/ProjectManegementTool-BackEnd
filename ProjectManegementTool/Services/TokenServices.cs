using Microsoft.IdentityModel.Tokens;
using ProjectManegementTool.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectManegementTool.Services
{
    public class TokenServices
    {
        private readonly IConfiguration _config;

        public TokenServices(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(Users us)
        {
            if (us == null || string.IsNullOrWhiteSpace(us.Email))
                throw new ArgumentException("Invalid user data for token generation");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, us.Email),
                new Claim(ClaimTypes.Role, us.RolesId ==  1 ? "Admin" : (us.RolesId == 2 ? "Maneger": "User"))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}






