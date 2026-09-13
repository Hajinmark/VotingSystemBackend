using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Persistence;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Application.Utilities;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Features.Roles.Command.CreateRoles
{
    public class CreateRolesCommandHandler : IRequestHandler<CreateRolesCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository roleRepository;

        public CreateRolesCommandHandler(IUnitOfWork _unitOfWork, IRoleRepository roleRepository)
        {
            this._unitOfWork = _unitOfWork;
            this.roleRepository = roleRepository; 
        }
        public async Task<string> Handle(CreateRolesCommand request)
        {
            var nameOfRole = await this.roleRepository.IsRoleExist(request.RoleName);

            try
            {
                if(nameOfRole.Contains("Not"))
                {
                    var roles = new Domain.Entities.Roles
                    (
                        request.RoleName    
                    );

                    await this.roleRepository.Add(roles);
                    await this._unitOfWork.Commit();

                    return "Successfully inserted new role";
                }
                return "Failed to insert new role";
            }
            catch
            {
                await this._unitOfWork.Rollback();
                throw;
            }
        }
    }
}
