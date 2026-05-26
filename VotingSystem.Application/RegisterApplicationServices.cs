using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Features.Users.Command.CreateUser;
using VotingSystem.Application.Features.Users.Command.LoginUser;
using VotingSystem.Application.Utilities;

namespace VotingSystem.Application
{
    public static class RegisterApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, SimpleMediator>();
            services.AddScoped<IRequestHandler<CreateUserCommand, string>, CreateUserCommandHandler>();
            services.AddScoped<IRequestHandler<LoginUserCommand, LoginResponseDTO>, LoginUserCommandHandler>();
            return services;   
        }
    }
}
