using API.Controllers.Base;
using Application.Authentication.Commands;
using Application.Authentication.Dto;
using Application.Authentication.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(IMediator mediator) : base(mediator) { }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModelDto model)
            => Ok(await Mediator.Send(new LoginUserQuery.Request(model)));

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModelDto model)
            => Ok(await Mediator.Send(new RegisterUserCommand.Request(model)));

        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModelDto model)
            => Ok(await Mediator.Send(new RegisterAdminCommand.Request(model)));

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(TokenModelDto tokenModel)
            => Ok(await Mediator.Send(new RefreshTokenCommand.Request(tokenModel)));

        [Authorize]
        [HttpPost("Revoke")]
        public async Task<IActionResult> Revoke(string username) 
            => Ok(await Mediator.Send(new RevokeUserCommand.Request(username)));

        [Authorize]
        [HttpPost("RevokeAll")]
        public async Task<IActionResult> RevokeAll()
            => Ok(await Mediator.Send(new RevokeAllUsersCommand.Request()));
    }
}