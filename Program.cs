using JwtAspNet;
using JwtAspNet.Models;
using JwtAspNet.Services;
using JwtAspNet.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

var app = builder.Build();

app.MapGet("/", (ITokenService TokenService) => TokenService.Create(new User(1, "Usuário", "email@dominio.com", "image", "password", ["role 1 - student", "role 2 - premium"])));

app.Run();
