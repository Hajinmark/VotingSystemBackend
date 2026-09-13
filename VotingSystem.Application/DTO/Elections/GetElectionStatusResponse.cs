using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Application.DTO.Elections
{
    public class GetElectionStatusResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}

