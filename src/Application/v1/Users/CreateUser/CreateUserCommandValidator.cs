using Fatec.Store.User.Application.Shared.Extensions;
using FluentValidation;

namespace Fatec.Store.User.Application.v1.Users.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Cpf)
                .Must(ValidateCpfLength)
                .WithMessage("CPF inválido!!!");
        }

        private bool ValidateCpfLength(string cpf) => cpf.UnformatCpf().Length == 11;
    }
}