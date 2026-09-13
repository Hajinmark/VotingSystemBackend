using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Persistence;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Application.Exceptions;
using VotingSystem.Application.Utilities;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Features.Users.Command.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IConfiguration config;

        public LoginUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
            this.config = config;   
        }
        public async Task<LoginResponseDTO> Handle(LoginUserCommand request)
        {
            var isUserOrEmailExist = await userRepository
                .IsEmailOrUsernameExist(request.Username, null);

            var user = await userRepository.GetByUsername(request.Username ?? "");
            
            try
            {
                if (isUserOrEmailExist.Contains("Not"))
                    throw new NotFoundException();

                var verified = VerifyPassword(user.PasswordHash, request.PasswordHash);

                if (verified == "Verified")
                {
                    var dto = new LoginResponseDTO()
                    {
                        Token = GenerateToken(user),
                        Username = request.Username,
                        Message = "Verified",
                        Success = true
                    };

                    return dto;
                }

                return new LoginResponseDTO()
                {
                    Token = "",
                    Username = request.Username,
                    Message = "Unauthorized",
                    Success = false
                };
            }

            catch
            {
                throw;
            } 
        }

        private string VerifyPassword(string password, string inputPassword)
        {
            var passwordHasher = new PasswordHasher<Object>();
            var hashedPassword = passwordHasher.VerifyHashedPassword(null, password, inputPassword);

            if (hashedPassword == PasswordVerificationResult.Success)
                return "Verified";

            else
                return "Unauthorized";
        }

        public string GenerateToken(UsersDTO user)
        {
            var role = userRepository.GetByUsername(user.Username);

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["Jwt:Key"] ?? "")
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Roles?.RoleName ?? "")
                
            };

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(
                    Convert.ToDouble(config["Jwt:ExpiryMinutes"])
                ),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
