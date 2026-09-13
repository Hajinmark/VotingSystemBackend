using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Persistence;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Persistence.Repositories;
using VotingSystem.Persistence.UnitOfWork;

namespace VotingSystem.Persistence
{
    public static class RegisterPersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VotingSystemDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("VotingSystemConnectionString")));

            services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmailService, EmailRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IElectionRepository, ElectionRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();

            return services;
        }
    }
}
