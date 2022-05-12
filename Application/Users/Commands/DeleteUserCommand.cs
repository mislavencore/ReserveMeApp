using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance;
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
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<object> Handle(Request request, CancellationToken cancellationToken)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
                //if (user == null) 
                //    return new { Error = "Unsuported user" };

                //_userManager.dele(user);
                //await _.SaveChangesAsync();

                return new { Success = "da" };
            }
        }
    }
}