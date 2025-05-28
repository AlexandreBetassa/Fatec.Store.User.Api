using Fatec.Store.Framework.Core.Bases.v1.Exceptions;
using System.Net;

namespace Fatec.Store.User.Infrastructure.CrossCutting.v1.Exceptions
{
    public class InvalidUserException(HttpStatusCode statusCode, string message) : CustomException(statusCode, message)
    {
    }
}
