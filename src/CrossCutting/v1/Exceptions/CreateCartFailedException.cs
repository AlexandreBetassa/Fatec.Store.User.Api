using Fatec.Store.Framework.Core.Bases.v1.Exceptions;
using System.Net;

namespace Fatec.Store.User.Infrastructure.CrossCutting.v1.Exceptions
{
    public class CreateCartFailedException(HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string message = "Erro ao criar o carrinho")
        : CustomException(statusCode, message)
    {
    }
}