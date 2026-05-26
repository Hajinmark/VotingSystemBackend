using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Models.Notification;

namespace VotingSystem.Application.Contracts.Repositories
{
    public interface IEmailService
    {
        Task SendEmailRegistration(RegisteredUserDTO data);
    }
}
