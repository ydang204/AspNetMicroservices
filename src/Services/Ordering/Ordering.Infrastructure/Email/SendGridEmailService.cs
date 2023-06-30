using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Models;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Email
{
    public class SendGridEmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<SendGridEmailService> _logger;

        public SendGridEmailService(IOptions<EmailSettings> mailSettings, ILogger<SendGridEmailService> logger)
        {
            _emailSettings = mailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Application.Models.Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            _logger.LogInformation($"Email sent with response {response}");

            return response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}