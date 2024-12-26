using JwtAspNet;
using JwtAspNet.Models;
using JwtAspNet.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();
builder.Services.AddSecurity();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

User user = new User(1, "Leandro", "lss.91@dominio.com", "image", "password", ["role 1 - student", "role 2 - premium"]);

app.MapGet("/login", (ITokenService TokenService) => TokenService.Create(user));

app.MapGet("/admin", () => "Acesso autorizado").RequireAuthorization();

app.Run();
