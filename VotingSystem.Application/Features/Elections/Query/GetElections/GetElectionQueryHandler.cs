using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Application.Utilities;

namespace VotingSystem.Application.Features.Elections.Query.GetElections
{
    public class GetElectionQueryHandler : IRequestHandler<GetElectionsQuery, List<GetElectionResponse>>
    {
        private readonly IElectionRepository repository;
        public GetElectionQueryHandler(IElectionRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetElectionResponse>> Handle(GetElectionsQuery request)
        {
            return await this.repository.GetElections();
        }
    }
}
