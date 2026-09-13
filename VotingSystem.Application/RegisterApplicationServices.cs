using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Application.Features.Elections.Command.CreateElection;
using VotingSystem.Application.Features.Elections.Query.ElectionStatus;
using VotingSystem.Application.Features.Elections.Query.GetElections;
using VotingSystem.Application.Features.Positions.Command;
using VotingSystem.Application.Features.Roles.Command.CreateRoles;
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
            services.AddScoped<IRequestHandler<CreateRolesCommand, string>, CreateRolesCommandHandler>();
            services.AddScoped<IRequestHandler<CreateElectionCommand, CreateElectionsRequest>, CreateElectionCommandHandler>();
            services.AddScoped<IRequestHandler<CreatePositionCommand, CreatePositionRequest>, CreatePositionCommandHandler>();
            services.AddScoped<IRequestHandler<GetElectionStatusQuery, GetElectionStatusResponse[]>, GetElectionStatusQueryHandler>();
            services.AddScoped<IRequestHandler<GetElectionsQuery, List<GetElectionResponse>>, GetElectionQueryHandler>();
            return services;   
        }
    }
}
