using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.WebToken
{
    public interface IWebTokenService
    {
        string GenerateRefreshToken();
        JwtSecurityToken CreateToken(List<Claim> authClaims);
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
