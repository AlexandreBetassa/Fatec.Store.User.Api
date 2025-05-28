using Fatec.Store.User.Application.v1.Enums;
using MediatR;

namespace Fatec.Store.User.Application.v1.Commands.Notification.SendEmail
{
    public class SendEmailCommand : IRequest<Unit>
    {
        public string Email { get; set; }

        public TypeEmailEnum Flow { get; set; }
    }
}
