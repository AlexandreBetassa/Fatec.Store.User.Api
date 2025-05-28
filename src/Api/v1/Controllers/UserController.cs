using Fatec.Store.Framework.Core.Bases.v1.Controllers;
using Fatec.Store.User.Application.v1.Commands.Users.PatchStatusUser;
using Fatec.Store.User.Application.v1.Queries.GetAllUsersAdmin;
using Fatec.Store.User.Application.v1.Queries.GetUserById;
using Fatec.Store.User.Application.v1.Users.CreateUser;
using Fatec.Store.User.Application.v1.Users.PutUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Fatec.Store.User.Api.v1.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController(IMediator mediator) : BaseController<UserController>(mediator)
    {
        [HttpPatch("{id}/status")]
        //[Authorize(Policy = nameof(AccessPoliciesEnum.Write))]
        public async Task<IActionResult> PatchAsync(int id) =>
            await ExecuteAsync(async () => await Mediator.Send(new PatchStatusUserCommand(id)), HttpStatusCode.NoContent);

        [HttpGet]
        [AllowAnonymous]
        //[Authorize(Policy = nameof(AccessPoliciesEnum.Write))]
        public async Task<IActionResult> GetAsync() =>
            await ExecuteAsync(async () => await Mediator.Send(new GetAllUsersAdminQuery()), HttpStatusCode.OK);

        [HttpGet("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = nameof(AccessPoliciesEnum.Write))]
        public async Task<IActionResult> GetUserByIdAsync(int id) =>
            await ExecuteAsync(async () => await Mediator.Send(new GetUserByIdQuery(id)), HttpStatusCode.OK);

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand request) =>
            await ExecuteAsync(async () => await Mediator.Send(request), HttpStatusCode.Created);

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutUserAsync([FromBody] PutUserCommand request, [FromRoute] int id)
        {
            request.Id = id;
            return await ExecuteAsync(async () => await Mediator.Send(request), HttpStatusCode.NoContent);
        }
    }
}