using AppSemTemplate.Services;
using AppSemTemplate.Configurate;
using AppSemTemplate.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddMvcConfiguration()
       .AddDependencyInjectionConfiguration()
       .AddIdentityConfiguration();

var app = builder.Build();

app.UseMvcConfiguration();

app.Run();