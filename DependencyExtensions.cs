using JwtAspNet.Services;
using JwtAspNet.Services.Contracts;

namespace JwtAspNet;

public static class DependencyExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<ITokenService, TokenService>();
    }
}