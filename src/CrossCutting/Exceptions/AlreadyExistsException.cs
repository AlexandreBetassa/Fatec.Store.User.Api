using Fatec.Store.Framework.Core.Bases.v1.Exceptions;
using System.Net;

namespace Fatec.Store.User.Infrastructure.CrossCutting.Exceptions
{
    public class AlreadyExistsException(
        HttpStatusCode statusCode = HttpStatusCode.Conflict, string message = "Conflict") 
        : CustomException(statusCode, message)
    {
    }
}
