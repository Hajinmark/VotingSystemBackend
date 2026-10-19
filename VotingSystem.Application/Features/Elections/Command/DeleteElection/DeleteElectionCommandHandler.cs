using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Persistence;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Application.Utilities;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Features.Elections.Command.DeleteElection
{
    public class DeleteElectionCommandHandler : IRequestHandler<DeleteElectionCommand, string>
    {
        private readonly IUnitOfWork unitOfWork;
        //private readonly IRepository<Election> electionRepository;
        //private readonly IRepository<UserElection> userElectionRepository;
        private readonly IElectionRepository repository;
        public DeleteElectionCommandHandler(IUnitOfWork unitOfWork,
             //IRepository<Election> repository,
             //IRepository<UserElection> userElectionRepository
             IElectionRepository repository
            )
        {
            this.unitOfWork = unitOfWork;   
            this.repository = repository;
            //this.electionRepository = repository;
            //this.userElectionRepository = userElectionRepository;
        }
        public async Task<string> Handle(DeleteElectionCommand request)
        {
            var data = await this.repository.DeleteElection(request.ElectionID);

            if (data == true)
            {
                await this.unitOfWork.Commit();
                return "Successfully Deleted";
            }

            return "Failed to Delete";
        }
    }
}
