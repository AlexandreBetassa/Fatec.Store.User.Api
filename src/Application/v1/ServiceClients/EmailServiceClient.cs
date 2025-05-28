using Fatec.Store.User.Domain.Interfaces.v1.Services;
using Fatec.Store.User.Infrastructure.CrossCutting;
using Fatec.Store.User.Infrastructure.CrossCutting.v1.Models;
using System.Net;
using System.Net.Mail;

namespace Fatec.Store.User.Application.v1.ServiceClients
{
    public class EmailServiceClient(AppsettingsConfigurations appsettingsConfigurations) : IEmailServiceClient
    {
        private readonly EmailConfiguration _emailConfiguration = appsettingsConfigurations.EmailConfiguration;

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            using var smtpClient = new SmtpClient(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort);
            smtpClient.Credentials = new NetworkCredential(_emailConfiguration.FromMail, _emailConfiguration.FromMailPassword);
            smtpClient.EnableSsl = true;

            using var mailMessage = new MailMessage(_emailConfiguration.FromMail, toEmail, subject, body);
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}