using Fatec.Store.Framework.Core.Bases.v1.Controllers;
using Fatec.Store.User.Application.v1.Commands.Notification.SendEmail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Fatec.Store.User.Api.v1.Controllers
{
    [Route("api/v1/notification")]
    [ApiController]
    public class NotificationController(IMediator mediator) : BaseController<AuthController>(mediator)
    {
        [HttpPost]
        public async Task<IActionResult> SendEmailAsync([FromBody] SendEmailCommand request) =>
             await ExecuteAsync(async () => await Mediator.Send(request), HttpStatusCode.Created);
    }
}