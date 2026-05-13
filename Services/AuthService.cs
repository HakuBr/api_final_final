using APIsprint.Data;
using APIsprint.DTOs.AuthDTOs;
using APIsprint.Services.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIsprint.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        private readonly IConfiguration _configuration;

        public AuthService(
            AppDbContext context,
            IConfiguration configuration)
        {
            _context = context;

            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginDTO dto)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a =>
                    a.email == dto.email &&
                    a.pass_word == dto.password);

            if (account == null)
                throw new Exception("Email ou senha inválidos");

            var claims = new[]
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    account.account_id.ToString()
                ),

                new Claim(
                    ClaimTypes.Email,
                    account.email
                ),

                new Claim(
                    ClaimTypes.Role,
                    "Client"
                )
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]
                )
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],

                audience: _configuration["Jwt:Audience"],

                claims: claims,

                expires: DateTime.Now.AddHours(2),

                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}