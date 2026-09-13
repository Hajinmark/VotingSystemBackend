using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Application.Utilities;
using VotingSystem.Domain.Enums;

namespace VotingSystem.Application.Features.Elections.Query.ElectionStatus
{
    public class GetElectionStatusQueryHandler : IRequestHandler<GetElectionStatusQuery, GetElectionStatusResponse[]>
    {
        public Task<GetElectionStatusResponse[]> Handle(GetElectionStatusQuery request)
        {
           var result = Enum.GetValues<VotingSystem.Domain.Enums.ElectionStatus>()
               .Select(x => new GetElectionStatusResponse
               {
                   Id = (int)x,
                   Name = x.ToString()
               }).ToArray();

            return Task.FromResult(result); 
        }
    }
}
