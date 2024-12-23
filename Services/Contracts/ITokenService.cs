using JwtAspNet.Models;

namespace JwtAspNet.Services.Contracts;

public interface ITokenService
{
    string Create(User user);
}