using Fatec.Store.Framework.Core.Bases.v1.Exceptions;
using System.Net;

namespace Fatec.Store.User.Infrastructure.CrossCutting.v1.Exceptions
{
    public class NotFoundException(string message, HttpStatusCode statusCode = HttpStatusCode.NotFound)
        : CustomException(statusCode, message)
    {
    }
}
