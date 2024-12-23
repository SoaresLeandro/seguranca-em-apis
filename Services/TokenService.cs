using System.IdentityModel.Tokens.Jwt;
using System.Text;
using JwtAspNet.Services.Contracts;
using Microsoft.IdentityModel.Tokens;

namespace JwtAspNet.Services;

public class TokenService : ITokenService
{
    public string Create()
    {
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2),
            IssuedAt = DateTime.UtcNow
        };

        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }
}