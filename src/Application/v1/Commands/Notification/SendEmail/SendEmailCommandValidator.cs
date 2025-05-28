using FluentValidation;

namespace Fatec.Store.User.Application.v1.Commands.Notification.SendEmail
{
    public class SendEmailCommandValidator : AbstractValidator<SendEmailCommand>
    {
        public SendEmailCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email não doi informado.");
        }
    }
}