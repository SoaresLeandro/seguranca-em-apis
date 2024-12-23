using JwtAspNet;
using JwtAspNet.Services;
using JwtAspNet.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

var app = builder.Build();

app.MapGet("/", (ITokenService TokenService) => TokenService.Create());

app.Run();
