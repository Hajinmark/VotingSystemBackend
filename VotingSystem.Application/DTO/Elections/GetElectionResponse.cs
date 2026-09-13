using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.DTO.Elections
{
    public class GetElectionResponse
    {
        public int ElectionId { get; set; }
        public string ElectionName { get; set; } = null!;
        public string? ElectionDescription { get; set; }
        public string ? StartDate { get; set; }
        public string ? EndDate { get; set; }
        public int ElectionStatus { get; set; }
        public int CreatedBy { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        public string CreatedByName { get; set; } = null!;
        public string StatusName { get; set; } = null!;
        public string Period { get; set; } = null!;

    }
}
