using Fatec.Store.User.Application.Enums.v1;
using MediatR;

namespace Fatec.Store.User.Application.Commands.v1.Notification.SendEmail
{
    public class SendEmailCommand : IRequest<Unit>
    {
        public string Email { get; set; }

        public TypeEmailEnum Flow { get; set; }
    }
}
