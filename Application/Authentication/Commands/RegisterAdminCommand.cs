using Application.Authentication.Dto;
using Application.Constants;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authentication.Commands
{
    public class RegisterAdminCommand
    {
        public class Request : IRequest<object>
        {
            public RegisterModelDto Model { get; set; }
            public Request(RegisterModelDto model) => Model = model;
        }

        public class Handler : IRequestHandler<Request, object>
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly UserManager<ApplicationUser> _userManager;

            public Handler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
            {
                _roleManager = roleManager;
                _userManager = userManager;
            }

            public async Task<object> Handle(Request request, CancellationToken cancellationToken)
            {
                var userExists = await _userManager.FindByNameAsync(request.Model.Username);
                if (userExists != null)
                    return new { Status = "Error", Message = "User already exists!" };

                var user = new ApplicationUser()
                {
                    Email = request.Model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.Model.Username,
                    CompanyId = request.Model.CompanyId
                };

                var result = await _userManager.CreateAsync(user, request.Model.Password);
                if (!result.Succeeded)
                    return new { Status = "Error", Message = "User creation failed! Please check user details and try again." };

                if (!await _roleManager.RoleExistsAsync(UserRolesConstants.Admin))
                    await _roleManager.CreateAsync(new IdentityRole(UserRolesConstants.Admin));
                if (!await _roleManager.RoleExistsAsync(UserRolesConstants.User))
                    await _roleManager.CreateAsync(new IdentityRole(UserRolesConstants.User));

                if (await _roleManager.RoleExistsAsync(UserRolesConstants.Admin))
                {
                    await _userManager.AddToRoleAsync(user, UserRolesConstants.Admin);
                }
                if (await _roleManager.RoleExistsAsync(UserRolesConstants.Admin))
                {
                    await _userManager.AddToRoleAsync(user, UserRolesConstants.User);
                }
                return new { Status = "Success", Message = "User created successfully!" };
            }
        }
    }
}