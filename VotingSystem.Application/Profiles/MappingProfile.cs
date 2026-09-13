using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.DTO.Elections;
using VotingSystem.Application.Features.Users.Command.CreateUser;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Users, UserDTO>();
            CreateMap<Election, CreateElectionsRequest>();
            CreateMap<Position, CreatePositionRequest>();
        }
    }
}
