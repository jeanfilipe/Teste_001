using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Teste_001.Domain.Repositories;
using Teste_001.Infrastructure.Entities;

namespace Teste_001.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        //public async Task<bool> RegisterAsync(UserViewModel model)
        //{
        //    if (await _userRepository.GetByEmailAsync(model.Email) != null)
        //        throw new Exception("E-mail já registrado!");

        //    var hashedPassword = HashPassword(model.Password);

        //    var user = new User
        //    {
        //        Name = model.Name,
        //        Email = model.Email,
        //        PasswordHash = hashedPassword
        //    };

        //    await _userRepository.AddAsync(user);
        //    return true;
        //}

        public async Task<string?> AuthenticateAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !VerifyPassword(password, user.Password))
                return null;

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Name)
        };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string HashPassword(string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes("mysalt123");
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            //return HashPassword(password) == storedHash;
            return password == storedHash;
        }
    }
}
