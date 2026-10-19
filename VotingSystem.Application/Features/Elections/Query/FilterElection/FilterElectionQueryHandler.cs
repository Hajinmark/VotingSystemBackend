using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Application.Utilities;

namespace VotingSystem.Application.Features.Elections.Query.FilterElection
{
    public class FilterElectionQueryHandler : IRequestHandler<FilterElectionQuery, List<GetElectionResponse>>
    {
        private readonly IElectionRepository repository;
        public FilterElectionQueryHandler(IElectionRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetElectionResponse>> Handle(FilterElectionQuery request)
        {
            var list = await repository.FilterElectionByName(request.ElectionName ?? "");
            return list;
        }
    }
}
