using API.Controllers.Base;
using Application.Users.Commands;
using Application.Users.Dto;
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

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterUserDto user) 
            => Ok(await Mediator.Send(new RegisterUserCommand.Request(user)));

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginUserDto user) 
            => Ok(await Mediator.Send(new LoginUserQuery.Request(user)));

        [HttpGet(nameof(Delete))]
        public async Task<IActionResult> Delete(string userId) 
            => Ok(await Mediator.Send(new DeleteUserCommand.Request(userId)));

        [HttpGet(nameof(GetById))]
        public async Task<IActionResult> GetById(string userId) 
            => Ok(await Mediator.Send(new GetUserDetailsByIdQuery.Request(userId)));

        //update
    }
}