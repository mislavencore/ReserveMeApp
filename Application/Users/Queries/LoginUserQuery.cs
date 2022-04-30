using Application.Users.Dto;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class LoginUserQuery
    {
        public class Request : IRequest<object>
        {
            public LoginUserDto User { get; set; }
            public Request(LoginUserDto user) => User = user;
        }

        public class Handler : IRequestHandler<Request, object>
        {
            private readonly SignInManager<ApplicationUser> _signInManager;

            public Handler(SignInManager<ApplicationUser> signInManager) => _signInManager = signInManager;

            public async Task<object> Handle(Request request, CancellationToken cancellationToken)
            {
                var result = await _signInManager.PasswordSignInAsync(request.User.UserName, request.User.Password, false, false);

                return new { Result = result };
            }
        }
    }
}