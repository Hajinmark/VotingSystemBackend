using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Domain.Enums
{
    public enum ElectionStatus
    {
        Draft = 1,
        Scheduled = 2,
        Open = 3,
        Closed = 4,
        Cancelled = 5,
        Archived = 6
    }
}
