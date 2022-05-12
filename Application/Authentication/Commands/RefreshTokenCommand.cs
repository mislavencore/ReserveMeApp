using Application.Authentication.Dto;
using Domain.Entities;
using Infrastructure.WebToken;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authentication.Commands
{
    public class RefreshTokenCommand
    {
        public class Request : IRequest<object>
        {
            public TokenModelDto TokenModel { get; set; }
            public Request(TokenModelDto tokenModel) => TokenModel = tokenModel;
        }

        public class Handler : IRequestHandler<Request, object>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IWebTokenService _tokenService;

            public Handler(UserManager<ApplicationUser> userManager, IWebTokenService tokenService)
            {
                _userManager = userManager;
                _tokenService = tokenService;
            }
            
            public async Task<object> Handle(Request request, CancellationToken cancellationToken)
            {
                if (request.TokenModel is null) 
                    return new { Status = "Invalid client request" };

                string? accessToken = request.TokenModel.AccessToken;
                string? refreshToken = request.TokenModel.RefreshToken;

                var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

                if (principal == null) 
                    return new { Status = "Invalid access token or refresh token" };

                string username = principal.Identity.Name;
                var user = await _userManager.FindByNameAsync(username);

                if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                    return new { Status = "Invalid access token or refresh token" };

                var newAccessToken = _tokenService.CreateToken(principal.Claims.ToList());
                var newRefreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = newRefreshToken;
                await _userManager.UpdateAsync(user);

                return new 
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                    RefreshToken = newRefreshToken
                };
            }
        }
    }
}