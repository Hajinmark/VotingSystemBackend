using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Models.Notification;
using VotingSystem.Application.Contracts.Persistence;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Application.Exceptions;
using VotingSystem.Application.Utilities;
using VotingSystem.Domain.Entities;


namespace VotingSystem.Application.Features.Users.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmailService emailService;
        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IEmailService emailService)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.emailService = emailService;
        }
        public async Task<string> Handle(CreateUserCommand request)
        {
            var isExist = await this.userRepository
                .IsEmailOrUsernameExist(request.Username, request.Email);

            try
            {
                if (isExist.Contains("Not"))
                {
                    var password = HashedPassword(request.PasswordHash);

                    // Users
                    var user = new Domain.Entities.Users
                    (
                        request.Username,
                        password,
                        request.RoleId == 0 ? 1 : request.RoleId
                    );

                    // UserDetails
                    user.UserDetails = new UserDetails
                    (
                        request.FirstName,
                        request.LastName,
                        request.Email
                    );

                    await this.userRepository.Add(user);
                    await this.unitOfWork.Commit();

                    var message = new RegisteredUserDTO()
                    {
                        Username = request.Username ?? "",
                        Email = request.Email ?? "",
                        RoleId = request.RoleId,
                        FirstName = request.FirstName ?? "",
                        LastName = request.LastName ?? ""
                    };

                    await this.emailService.SendEmailRegistration(message);
                    return "Created new user";
                }

                throw new AlreadyExistsException("Username or Email already exist");
            }
            catch
            {
                await this.unitOfWork.Rollback();
                throw;
            }
            
        }

        private string HashedPassword(string password)
        {
            var hasher = new PasswordHasher<object>();
            string hashed = hasher.HashPassword(null, password);
            return hashed;
        }
    }
}
