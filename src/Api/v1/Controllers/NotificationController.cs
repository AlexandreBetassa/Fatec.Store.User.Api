using Fatec.Store.Framework.Core.Bases.v1.Controllers;
using Fatec.Store.User.Application.v1.Commands.Notification.SendEmail;
using Fatec.Store.User.Domain.Enums.v1;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Fatec.Store.User.Api.v1.Controllers
{
    [Route("api/v1/notification")]
    [ApiController]
    public class NotificationController(IMediator mediator) : BaseController<AuthController>(mediator)
    {
        [HttpPost]
        [Authorize(Policy = nameof(RolesUserEnum.All))]
        public async Task<IActionResult> SendEmailAsync([FromBody] SendEmailCommand request) =>
            await ExecuteAsync(async () => await Mediator.Send(request), HttpStatusCode.Created);
    }
}