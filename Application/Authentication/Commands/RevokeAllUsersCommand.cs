using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authentication.Commands
{
    public class RevokeAllUsersCommand
    {
        public class Request : IRequest<object> { }

        public class Handler : IRequestHandler<Request, object>
        {
            private readonly UserManager<ApplicationUser> _userManager;

            public Handler(UserManager<ApplicationUser> userManager) => _userManager = userManager;

            public async Task<object> Handle(Request request, CancellationToken cancellationToken)
            {
                var users = _userManager.Users.ToList();
                foreach (var user in users)
                {
                    user.RefreshToken = null;
                    await _userManager.UpdateAsync(user);
                }

                return new { Status = "All users are revoked"};
            }
        }
    }
}