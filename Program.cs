using AutologApi.API.Endpoints;
using AutologApi.API.Infra.Repository;
using AutologApi.API.Settings;
using AutologApi.API.UseCases;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContext<AppDbContext>();

builder.Services.AddSingleton<TokenService>();

// Auth
builder.Services.AddScoped<AuthLoginUseCase>();
//Users
builder.Services.AddScoped<CreateUserClientUseCase>();
builder.Services.AddScoped<TransferCarUseCase>();
builder.Services.AddScoped<CreateUserGarageUseCase>();
// Client
builder.Services.AddScoped<GetClientUseCase>();
//Car
builder.Services.AddScoped<CreateCarUseCase>();
builder.Services.AddScoped<GetCarByLicenseUseCase>();
builder.Services.AddScoped<ListClientCarsUseCase>();

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

