using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Application.Contracts.Models.Notification;
using VotingSystem.Application.Contracts.Repositories;

namespace VotingSystem.Persistence.Repositories
{
    public class EmailRepository : IEmailService
    {
        private readonly VotingSystemDbContext context;
        private readonly IConfiguration configuration;
        public EmailRepository(VotingSystemDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration; 
        }

        public async Task SendEmailRegistration(RegisteredUserDTO data)
        {
            var subject = "Successfully Registered - Voting System";
            var body = $"""
                Welcome!,

                Hi {data.FirstName} {data.LastName}

                Your registration was successful. You can now log in.

                Username : {data.Username}

                Thank you!
                """;
            await SendEmail(data.Email, subject, body);
        }

        private async Task SendEmail(string to, string subject, string body)
        {
            try
            {
                var from = configuration["EmailSettings:Email"] ?? "";
                var password = configuration["EmailSettings:Password"];
                var host = configuration["EmailSettings:Host"];
                var port = int.Parse(configuration["EmailSettings:Port"] ?? "25");

                using var smtpClient = new SmtpClient(host, port)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(from, password)
                };

                using var message = new MailMessage(from, to, subject, body);
                await smtpClient.SendMailAsync(message);
            }
            catch
            {
                throw;
            }
        }
    }
}
