using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public class DeleteUserCommand
    {
        public class Request : IRequest<object>
        {
            public string UserId { get; set; }
            public Request(string userId) => UserId = userId;
        }

        public class Handler : IRequestHandler<Request, object>
        {
            private UserManager<ApplicationUser> _userManager;

            public Handler(UserManager<ApplicationUser> userManager) => _userManager = userManager;

            public async Task<object> Handle(Request request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.UserId);

                var result = await _userManager.DeleteAsync(user);

                return new { Result = result };
            }
        }
    }
}