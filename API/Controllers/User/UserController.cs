using API.Controllers.Base;
using Application.Users.Commands;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator) { }

        [HttpGet(nameof(Delete))]
        public async Task<IActionResult> Delete(string userId)
            => Ok(await Mediator.Send(new DeleteUserCommand.Request(userId)));

        [HttpGet(nameof(GetById))]
        public async Task<IActionResult> GetById(string userId)
            => Ok(await Mediator.Send(new GetUserDetailsByIdQuery.Request(userId)));

        //update
    }
}