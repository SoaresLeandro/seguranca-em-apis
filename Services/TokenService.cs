using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAspNet.Models;
using JwtAspNet.Services.Contracts;
using Microsoft.IdentityModel.Tokens;

namespace JwtAspNet.Services;

public class TokenService : ITokenService
{
    public string Create(User user)
    {
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2),
            IssuedAt = DateTime.UtcNow,
            Subject = GenerateClaimns(user)
        };

        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }

    private static ClaimsIdentity GenerateClaimns(User user)
    {
        var claimIdenty = new ClaimsIdentity();

        claimIdenty.AddClaim(new Claim(ClaimTypes.Name, user.Email));
        claimIdenty.AddClaim(new Claim(ClaimTypes.Email, user.Email));
        claimIdenty.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
        claimIdenty.AddClaim(new Claim("id", user.Id.ToString()));
        claimIdenty.AddClaim(new Claim("image", user.Image));

        foreach(var role in user.Roles)
            claimIdenty.AddClaim(new Claim(ClaimTypes.Role, role));

        return claimIdenty;
    }
}