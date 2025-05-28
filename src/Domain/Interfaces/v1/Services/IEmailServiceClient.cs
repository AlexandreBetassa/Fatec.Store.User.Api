namespace Fatec.Store.User.Domain.Interfaces.v1.Services
{
    public interface IEmailServiceClient
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
