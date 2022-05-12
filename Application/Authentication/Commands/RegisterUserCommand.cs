using Application.Authentication.Dto;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authentication.Commands
{
    public class RegisterUserCommand
    {
        public class Request : IRequest<object>
        {
            public RegisterModelDto Model { get; set; }
            public Request(RegisterModelDto model) => Model = model;
        }

        public class Handler : IRequestHandler<Request, object>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            public Handler(UserManager<ApplicationUser> userManager) => _userManager = userManager;

            public async Task<object> Handle(Request request, CancellationToken cancellationToken)
            {
                var userExists = await _userManager.FindByNameAsync(request.Model.Username);
                if (userExists != null)
                    return new { Status = "Error", Message = "User already exists!" };

                ApplicationUser user = new ApplicationUser()
                {
                    Email = request.Model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.Model.Username,
                    CompanyId = request.Model.CompanyId
                };

                var result = await _userManager.CreateAsync(user, request.Model.Password);
                if (!result.Succeeded)
                    return new { Status = "Error", Message = "User creation failed! Please check user details and try again." };

                return new { Status = "Success", Message = "User created successfully!" };
            }
        }
    }
}