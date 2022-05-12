using Application.Authentication.Dto;
using Domain.Entities;
using Infrastructure.WebToken;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authentication.Queries
{
    public class LoginUserQuery
    {
        public class Request : IRequest<object>
        {
            public LoginModelDto Model { get; set; }
            public Request(LoginModelDto model) => Model = model;
        }

        public class Handler : IRequestHandler<Request, object>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IConfiguration _configuration;
            private readonly IWebTokenService _tokenService;

            public Handler(UserManager<ApplicationUser> userManager, IConfiguration configuration, IWebTokenService tokenService)
            {
                _userManager = userManager;
                _configuration = configuration;
                _tokenService = tokenService;
            }

            public async Task<object> Handle(Request request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(request.Model.Username);
                if (user != null && await _userManager.CheckPasswordAsync(user, request.Model.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var token = _tokenService.CreateToken(authClaims);
                    var refreshToken = _tokenService.GenerateRefreshToken();

                    _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

                    user.RefreshToken = refreshToken;
                    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

                    await _userManager.UpdateAsync(user);

                    return new
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        RefreshToken = refreshToken,
                        Expiration = token.ValidTo
                    };
                }

                return new { Error = "Unauthorized" };
            }
        }
    }
}