using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.DTO.Positions;
using VotingSystem.Application.Utilities;

namespace VotingSystem.Application.Features.Positions.Query.GetPositions
{
    public class GetPositionsQuery : IRequest<List<GetPositionsDTO>>
    {
        public string ? ElectionName { get; set; }
        public string ? PositionName { get; set; }
    }
}
