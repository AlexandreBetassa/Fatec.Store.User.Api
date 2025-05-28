using MediatR;

namespace Fatec.Store.User.Application.v1.Commands.Auth.GenerateToken
{
    public class GenerateTokenCommand : IRequest<GenerateTokenResponse>
    {
        /// <summary>
        /// Email ou username.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha.
        /// </summary>
        public string Password { get; set; }
    }
}