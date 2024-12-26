using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace JwtAspNet;

public static class Security
{
    public static void AddSecurity(this IServiceCollection services)
    {
        services
        .AddAuthentication(a => 
        {
            a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(a =>
        {
            a.TokenValidationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.PrivateKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        
        services.AddAuthorization();
    }
}