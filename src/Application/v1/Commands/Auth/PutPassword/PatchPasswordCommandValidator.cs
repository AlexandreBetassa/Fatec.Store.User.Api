using FluentValidation;

namespace Fatec.Store.User.Application.v1.Commands.Auth.PutPassword
{
    public class PatchPasswordCommandValidator : AbstractValidator<PatchPasswordCommand>
    {
        public PatchPasswordCommandValidator()
        {
            RuleFor(x => x.EmailCode)
                .NotEmpty()
                .WithMessage("Código não foi informado.");

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .WithMessage("Nova senha não foi informada.");

            RuleFor(x => x.ConfirmNewPassword)
                .NotEmpty()
                .WithMessage("Confirmação da nova senha não foi informada.");
        }
    }
}
