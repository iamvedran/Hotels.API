using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hotels.API.Contracts;
using Hotels.API.Models.Users;
using Microsoft.IdentityModel.Tokens;

namespace Hotels.API.Repository
{
    public class AuthManager  : IAuthManager
    {
        private readonly IConfiguration _configuration;

        public AuthManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// login user, hardcoded for testing
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns>JWT Token</returns>
        public async Task<AuthResponseDTO> Login(LoginDTO loginDto)
        {
            if (loginDto.Email=="vedran@gmail.com" && loginDto.Password == "123456")
            {
                var token = await GenerateToken(loginDto.Email);

                return new AuthResponseDTO { Token = token };
            }

            return null;
        }

        /// <summary>
        /// Generate JWT token
        /// </summary>
        /// <param name="email"></param>
        /// <returns>JWT Token</returns>
        private async Task<string> GenerateToken(string email)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);


            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),

            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
