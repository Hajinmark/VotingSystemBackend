using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Repositories;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Domain.Entities;
using VotingSystem.Domain.Enums;

namespace VotingSystem.Persistence.Repositories
{
    public class ElectionRepository : Repository<Election>, IElectionRepository
    {
        private readonly VotingSystemDbContext context;
        public ElectionRepository(VotingSystemDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<string> AddUserElection(UserElection request)
        {
           try
           {
                var data = await context.UserElections.AddAsync(request);

                if(data != null)
                {
                    return "Added";
                }

                return "No value";
           }
           catch
           {
                throw;
           }
        }

        public async Task<List<GetElectionResponse>> GetElections()
        {
            try
            {
               
                var query = from election in this.context.Elections
                            join users in this.context.Users
                            on election.CreatedBy equals users.Id
                            select new GetElectionResponse
                            {
                                ElectionId = election.Id,
                                ElectionName = election.Title,
                                ElectionDescription = election.Description,
                                StartDate = election.StartDate.ToString("MMMM d, yyyy hh:mm tt"),
                                EndDate = election.EndDate.ToString("MMMM d, yyyy hh:mm tt"),
                                ElectionStatus = election.Status,
                                StatusName = ((ElectionStatus)election.Status).ToString(),
                                CreatedBy = election.CreatedBy,
                                CreatedByName = users.Username,
                                CreatedAt = election.CreatedAt.ToString("MMMM d, yyyy hh:mm tt"),
                                UpdatedAt = election.UpdatedAt.ToString("MMMM d, yyyy hh:mm tt"),
                                Period = election.StartDate.ToString("MMMM d, yyyy hh:mm tt") + " - " + election.EndDate.ToString("MMMM d, yyyy hh:mm tt")
                            };

                return await query.ToListAsync();  

            }
            catch
            {
                throw;
            }
            
        }

        public async Task<int> IsElectionTitleExist(string title)
        {   
            try
            {
                var electionTitle = await context.Elections.AnyAsync(x => x.Title == title);

                if(!electionTitle)
                    return 0;

                return 1;

            }
            catch
            {
                throw;
            }
        }

    }
}
