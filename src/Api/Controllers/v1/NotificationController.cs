using Fatec.Store.Framework.Core.Bases.v1.Controllers;
using Fatec.Store.User.Application.Commands.v1.Notification.SendEmail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Fatec.Store.User.Api.Controllers.v1
{
    [Route("api/v1")]
    [ApiController]
    public class NotificationController(IMediator mediator) : BaseController<AuthController>(mediator)
    {
        [HttpPost("recovery")]
        public async Task<IActionResult> SendEmailAsync([FromBody] SendEmailCommand request) =>
             await ExecuteAsync(async () => await Mediator.Send(request), HttpStatusCode.Created);
    }
}