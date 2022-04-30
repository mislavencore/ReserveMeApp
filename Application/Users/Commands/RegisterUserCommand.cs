using Application.Users.Dto;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public class RegisterUserCommand
    {
        public class Request : IRequest<object>
        {
            public RegisterUserDto User { get; set; }
            public Request(RegisterUserDto user) => User = user;
        }

        public class Handler : IRequestHandler<Request, object>
        {
            private UserManager<ApplicationUser> _userManager;

            public Handler(UserManager<ApplicationUser> userManager) => _userManager = userManager;

            public async Task<object> Handle(Request request, CancellationToken cancellationToken)
            {
                var applicationUser = new ApplicationUser()
                {
                    UserName = request.User.UserName,
                    Email = request.User.Email,
                    CompanyId = request.User.CompanyId
                };

                var result = await _userManager.CreateAsync(applicationUser, request.User.Password);

                return result;
            }
        }
    }
}