using System.Text;
using System.Text.Json.Serialization;
using AutologApi.API.Endpoints;
using AutologApi.API.Exceptions;
using AutologApi.API.Infra.Repository;
using AutologApi.API.UseCases;
using AutologApi.API.UseCases.Auth;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var secretKeyBytes = Encoding.ASCII.GetBytes(TokenService.SecretByte);

builder
    .Services.AddAuthentication(config =>
    {
        config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(config =>
    {
        config.RequireHttpsMetadata = false;
        config.SaveToken = true;
        config.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddSingleton<TokenService>();
builder.Services.AddSingleton<PasswordService>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

// Auth
builder.Services.AddScoped<AuthLoginUseCase>();

//Users
builder.Services.AddScoped<CreateUserClientUseCase>();
builder.Services.AddScoped<TransferCarUseCase>();
builder.Services.AddScoped<CreateUserGarageUseCase>();

// Client
builder.Services.AddScoped<GetClientUseCase>();
builder.Services.AddScoped<GetClientCarsUseCase>();

//Car
builder.Services.AddScoped<CreateCarUseCase>();
builder.Services.AddScoped<GetCarByLicenseUseCase>();
builder.Services.AddScoped<ListClientCarsUseCase>();

//Budget
builder.Services.AddScoped<CreateBudgetUseCase>();
builder.Services.AddScoped<GetBudgetUseCase>();
builder.Services.AddScoped<ListBudgetsUseCase>();
builder.Services.AddScoped<CreateBudgetItemUseCase>();
builder.Services.AddScoped<DeleteBudgetItemUseCase>();
builder.Services.AddScoped<UpdateStatusBudgetUseCase>();
builder.Services.AddScoped<GetWhatsAppLinkBudgetUseCase>();
builder.Services.AddScoped<ObservationUpdateUseCase>();

// Dashboard
builder.Services.AddScoped<GarageDashboardUseCase>();

var app = builder.Build();

// TODO: Previne o erro de data no Postgre, pensar em uma fomra melhor de adaptar isso
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<AppDbContext>();
    try
    {
        Console.WriteLine("Applying database migrations...");
        dbContext.Database.Migrate();
        Console.WriteLine("Migrations applied successfully.");
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "[ERROR] Occured error on Migrations execution!!");
        throw;
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddGlobalErrorHandler();
app.UseAuthentication();
app.UseCors();

// app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
