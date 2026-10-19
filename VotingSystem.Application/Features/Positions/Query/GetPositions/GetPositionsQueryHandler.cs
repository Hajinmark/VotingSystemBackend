using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Application.DTO.Positions;
using VotingSystem.Application.Utilities;

namespace VotingSystem.Application.Features.Positions.Query.GetPositions
{
    public class GetPositionsQueryHandler : IRequestHandler<GetPositionsQuery, List<GetPositionsDTO>>
    {
        private readonly IPositionRepository service;
        public GetPositionsQueryHandler(IPositionRepository service)
        {
            this.service = service;
        }
        public async Task<List<GetPositionsDTO>> Handle(GetPositionsQuery request)
        {
            var result = await service.RetrievePositionsData(request);
            return result;
        }
    }
}
