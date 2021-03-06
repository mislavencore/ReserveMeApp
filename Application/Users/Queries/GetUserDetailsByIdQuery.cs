using Application.Authentication.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserDetailsByIdQuery
    {
        public class Request : IRequest<ApplicationUserDto>
        {
            public string UserId { get; set; }
            public Request(string userId) => UserId = userId;
        }

        public class Handler : IRequestHandler<Request, ApplicationUserDto>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<ApplicationUserDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
                return _mapper.Map<ApplicationUserDto>(user);
            }
        }
    }
}