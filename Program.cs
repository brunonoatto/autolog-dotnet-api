using AutologApi.API.Endpoints;
using AutologApi.API.Infra.Repository;
using AutologApi.API.Settings;
using AutologApi.API.UseCases.Auth;
using AutologApi.API.UseCases.Client;
using AutologApi.API.UseCases.UserClient;
using AutologApi.API.UseCases.UserGarage;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContext<AppDbContext>();

builder.Services.AddSingleton<TokenService>();
builder.Services.AddScoped<AuthLoginUseCase>();
builder.Services.AddScoped<CreateUserClientUseCase>();
builder.Services.AddScoped<CreateUserGarageUseCase>();
builder.Services.AddScoped<GetClientUseCase>();

var app = builder.Build();

// TODO: Previne o erro de data no Postgre, pensar em uma fomra melhor de adaptar isso
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();

