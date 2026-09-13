using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Domain.Enums
{
    public enum PositionValidationResult
    {
        Valid = 0,
        NameAlreadyExists = 1,
        DisplayOrderAlreadyExists = 2
    }
}
