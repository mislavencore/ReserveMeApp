using Application.Users.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserDetailsByIdQuery
    {
        public class Request : IRequest<ApplicationUserDetailsDto>
        {
            public string UserId { get; set; }
            public Request(string userId) => UserId = userId;
        }

        public class Handler : IRequestHandler<Request, ApplicationUserDetailsDto>
        {
            private UserManager<ApplicationUser> _userManager;
            private readonly IMapper _mapper;

            public Handler(UserManager<ApplicationUser> userManager, IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<ApplicationUserDetailsDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var user = await _userManager.Users
                    .Include(x => x.Company)
                    .ThenInclude(y => y.Settings)
                    .SingleAsync(x => x.Id == request.UserId);

                return _mapper.Map<ApplicationUserDetailsDto>(user);
            }
        }
    }
}